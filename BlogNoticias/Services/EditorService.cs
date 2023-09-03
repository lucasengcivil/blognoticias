using AutoMapper;
using BlogNoticias.Data.Dtos;
using BlogNoticias.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogNoticias.Services
{
    public class EditorService
    {
        private IMapper _mapper;
        private UserManager<Editor> _userManager;
        private SignInManager<Editor> _signInManager;
        private TokenService _tokenService;

        public EditorService(IMapper mapper,
            UserManager<Editor> userManager,
            SignInManager<Editor> signInManager,
            TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        public async Task Cadastra(CreateEditorDto dto)
        {
            Editor editor = _mapper.Map<Editor>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(editor, dto.Password);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Falha ao cadastrar usuário");
            }
        }

        public async Task<string> Login(LoginEditorDto dto)
        {
            var resultado = await
                _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }

            var editor = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(editor);

            return token;
        }
    }
}
