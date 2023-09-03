using AutoMapper;
using BlogNoticias.Data.Dtos;
using BlogNoticias.Models;
using NoticiasApi.Data.Dtos;
using NoticiasApi.Models;

namespace NoticiasApi.Profiles;

public class NoticiaProfile : Profile
{
    public NoticiaProfile()
    {
        CreateMap<CreateNoticiaDto, Noticia>();
        CreateMap<UpdateNoticiaDto, Noticia>();
        CreateMap<Noticia, UpdateNoticiaDto>();
        CreateMap<Noticia, ReadNoticiaDto>();
        CreateMap<CreateEditorDto, Editor>();
    }
}