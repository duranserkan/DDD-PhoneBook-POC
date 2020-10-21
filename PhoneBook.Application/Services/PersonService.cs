using Common.Models;
using PhoneBook.Application.Models;
using PhoneBook.Contract.Requests;
using PhoneBook.Domain.ContactAggregate;
using PhoneBook.Domain.PersonAggregate;
using SharedKernel.Interfaces;
using System;
using System.Threading.Tasks;
using PhoneBook.Contract.Requests.Phone;

namespace PhoneBook.Application.Services
{
	public interface IPersonService
	{
		Task<PagedResponse<PersonDto>> GetPeopleAsync(PageFilter pageFilter);
		Task<PersonDto> GetPersonAsync(Guid personId);
		Task<PersonDto> SaveAsync(PostPersonRequest request);
		Task<PersonDto> PatchAsync(PatchPersonRequest request);
		Task<PersonDto> DeletePersonAsync(Guid personId);
	}

	public class PersonService : IPersonService
	{
		private readonly IPersonRepository _personRepository;
		private readonly IContactRepository _contactRepository;
		private readonly IUnitOfWork _unitOfWork;

		public PersonService(IPersonRepository personRepository, IUnitOfWork unitOfWork, IContactRepository contactRepository)
		{
			_personRepository = personRepository;
			_unitOfWork = unitOfWork;
			_contactRepository = contactRepository;
		}

		public async Task<PagedResponse<PersonDto>> GetPeopleAsync(PageFilter pageFilter)
		{
			var people = await _personRepository.ListAsync(pageFilter.Skip, pageFilter.PageSize);
			var totalCount = await _personRepository.CountAsync();
			var response = new PagedResponse<PersonDto>(PersonDto.MapFrom(people), pageFilter.PageNumber, pageFilter.PageSize, totalCount);

			return response;
		}

		public async Task<PersonDto> GetPersonAsync(Guid personId)
		{
			if (personId == default) return null;

			var person = await _personRepository.GetByIdAsync(personId);

			return PersonDto.MapFrom(person);
		}

		public async Task<PersonDto> SaveAsync(PostPersonRequest request)
		{
			var person = new Person(request.Name, request.Surname, request.CompanyName, request.PhoneId, request.EmailId, request.LocationId);
			person = await _personRepository.AddAsync(person);
			await _unitOfWork.SaveChangesAsync();
			//Todo: publish person created event

			return PersonDto.MapFrom(person);
		}

		public async Task<PersonDto> PatchAsync(PatchPersonRequest request)
		{
			if (request.PersonId == default) throw new ArgumentException("PersonId can not be empty");

			var person = await _personRepository.GetByIdAsync(request.PersonId);

			person.Name = request.Name ?? person.Name;
			person.Surname = request.Surname ?? person.Surname;
			person.CompanyName = request.CompanyName ?? person.CompanyName;

			if (request.PhoneId != default)
			{
				var phoneContact = await _contactRepository.GetByIdAsync(request.PhoneId.Value);
				person.AddPhone(phoneContact);
			}

			if (request.EmailId != default)
			{
				var emailContact = await _contactRepository.GetByIdAsync(request.EmailId.Value);
				person.AddEmail(emailContact);
			}

			if (request.LocationId != default)
			{
				var locationContact = await _contactRepository.GetByIdAsync(request.LocationId.Value);
				person.AddLocation(locationContact);
			}

			await _unitOfWork.SaveChangesAsync();

			return PersonDto.MapFrom(person);
		}

		public async Task<PersonDto> DeletePersonAsync(Guid personId)
		{
			var person = await _personRepository.GetByIdAsync(personId);
			if (person != null)
			{
				await _personRepository.DeleteAsync(person);
				//Todo: publish person deleted event
			}

			return PersonDto.MapFrom(person);
		}
	}
}
