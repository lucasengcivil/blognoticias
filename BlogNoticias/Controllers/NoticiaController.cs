using AutoMapper;
using NoticiasApi.Data;
using NoticiasApi.Data.Dtos;
using NoticiasApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace NoticiasApi.Controllers;

[ApiController]
[Route("[controller]")]
public class NoticiaController : ControllerBase
{

    private NoticiaContext _context;
    private IMapper _mapper;

    public NoticiaController(NoticiaContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionaNoticia([FromBody] CreateNoticiaDto noticiaDto)
    {
        Noticia noticia = _mapper.Map<Noticia>(noticiaDto);
        _context.Noticias.Add(noticia);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaNoticiaPorId), new { id = noticia.Id }, noticia);
    }

    [HttpGet]
    public IEnumerable<ReadNoticiaDto> RecuperaNoticias([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadNoticiaDto>>(_context.Noticias.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaNoticiaPorId(int id)
    {
        var noticia = _context.Noticias.FirstOrDefault(noticia => noticia.Id == id);
        if (noticia == null) return NotFound();
        var noticiaDto = _mapper.Map<ReadNoticiaDto>(noticia);
        return Ok(noticiaDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaNoticia(int id, [FromBody] UpdateNoticiaDto noticiaDto)
    {
        var noticia = _context.Noticias.FirstOrDefault(noticia => noticia.Id == id);
        if (noticia == null) return NotFound();
        _mapper.Map(noticiaDto, noticia);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaNoticiaParcial(int id, JsonPatchDocument<UpdateNoticiaDto> patch)
    {
        var noticia = _context.Noticias.FirstOrDefault(noticia => noticia.Id == id);
        if (noticia == null) return NotFound();
        
        var noticiaParaAtualizar = _mapper.Map<UpdateNoticiaDto>(noticia);

        patch.ApplyTo(noticiaParaAtualizar, ModelState);

        if (!TryValidateModel(noticiaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(noticiaParaAtualizar, noticia);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaNoticia(int id)
    {
        var noticia = _context.Noticias.FirstOrDefault(noticia => noticia.Id == id);
        if (noticia == null) return NotFound();
        _context.Remove(noticia);
        _context.SaveChanges();
        return NoContent();
    }
}
