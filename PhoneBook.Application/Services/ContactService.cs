using Common.Models;
using PhoneBook.Application.Models;
using PhoneBook.Contract.Requests.Contact;
using PhoneBook.Domain.ContactAggregate;
using SharedKernel.Interfaces;
using System;
using System.Threading.Tasks;

namespace PhoneBook.Application.Services
{
	public interface IContactService
	{
		Task<PagedResponse<ContactDto>> GetContactsAsync(PageFilter pageFilter);
		Task<ContactDto> GetContactAsync(Guid contactId);
		Task<ContactDto> SaveAsync(PostContactRequest request);
		Task<ContactDto> DeleteContactAsync(Guid contactId);
	}

	public class ContactService : IContactService
	{
		private readonly IContactRepository _contactRepository;
		private readonly IUnitOfWork _unitOfWork;

		public ContactService(IContactRepository contactRepository, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_contactRepository = contactRepository;
		}

		public async Task<PagedResponse<ContactDto>> GetContactsAsync(PageFilter pageFilter)
		{
			var people = await _contactRepository.ListAsync(pageFilter.Skip, pageFilter.PageSize);
			var totalCount = await _contactRepository.CountAsync();
			var response = new PagedResponse<ContactDto>(ContactDto.MapFrom(people), pageFilter.PageNumber, pageFilter.PageSize, totalCount);

			return response;
		}

		public async Task<ContactDto> GetContactAsync(Guid contactId)
		{
			if (contactId == default) return null;

			var contact = await _contactRepository.GetByIdAsync(contactId);

			return ContactDto.MapFrom(contact);
		}

		public async Task<ContactDto> SaveAsync(PostContactRequest request)
		{
			var contact = new Contact(request.ContactType, request.Content);
			contact = await _contactRepository.AddAsync(contact);
			await _unitOfWork.SaveChangesAsync();
			//Todo: publish contact created event

			return ContactDto.MapFrom(contact);
		}


		public async Task<ContactDto> DeleteContactAsync(Guid contactId)
		{
			var contact = await _contactRepository.GetByIdAsync(contactId);
			if (contact != null)
			{
				await _contactRepository.DeleteAsync(contact);
				//Todo: publish Contact deleted event
			}

			return ContactDto.MapFrom(contact);
		}
	}
}
