using AutoMapper;
using BlogNoticias.Data.Dtos;
using BlogNoticias.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BlogNoticias.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EditorController : ControllerBase
    {
        private EditorService _editorService;

        public EditorController(EditorService cadastroService)
        {
            _editorService = cadastroService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario(CreateEditorDto dto)
        {
            await _editorService.Cadastra(dto);
            return Ok("Usuário cadastrado!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginEditorDto dto)
        {
            var token = await _editorService.Login(dto);
            return Ok(token);
        }
    }
}
