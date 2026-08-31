using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.Author;
using BookStoreApp.API.Models.Book;
using BookStoreApp.API.Models.User;

namespace BookStoreApp.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDTO, Author>().ReverseMap();
            CreateMap<AuthorUpdateDTO, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDTO, Author>().ReverseMap();



            CreateMap<BookCreateDTO, Book>().ReverseMap();
            CreateMap<BookUpdateDTO, Book>().ReverseMap();
            CreateMap<Book, BookReadOnlyDTO>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => 
                src.Author !=null ? $"{src.Author.FirstName}-{src.Author.LastName}" : String.Empty))
                .ReverseMap();
           CreateMap<Book, BookDetailsDTO>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src =>
                 src.Author != null ? $"{src.Author.FirstName}-{src.Author.LastName}" : String.Empty))
                 .ReverseMap();

            CreateMap<ApiUser,UserDTO>().ReverseMap();
        }
    }
}
