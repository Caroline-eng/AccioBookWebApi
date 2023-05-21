using AccioBook.Domain.Entities;
using AccioBook.Domain.Interfaces.Services;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{

    /// <summary>
    /// AccioBook documentação  
    /// </summary>
    [Route("language")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        /// <summary>
        /// Insere um novo idioma no banco.
        /// </summary>     
        /// <returns></returns>        
        [HttpPost("insert")]
        public async Task<IActionResult> Insert(LanguageModel languageArgs)
        {
            var language = new Language();

            language.Name = languageArgs.Name;


            language = await _languageService.AddAndSaveAsync(language);

            if (language.Id != default(int))
            {
                return Ok(language);
            }

            return BadRequest();
        }


        /// <summary>
        /// Deleta um idioma do banco
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{languageId}")]
        public async Task<IActionResult> DeleteLanguage(Int64 languageId)
        {

            try
            {
                await _languageService.DeleteAsync(languageId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///Altera um idioma no banco
        /// </summary>
        /// <returns></returns>
        [HttpPut("update/{languageId}")]
        public async Task<IActionResult> UpdateLanguage(Int64 languageId, LanguageModel languageArgs)
        {

            var language = await _languageService.GetAsync(languageId);

            if (language == null)
            {
                return NotFound();
            }

            language.Name = languageArgs.Name;


            await _languageService.UpdateAndSaveAsync(language);

            return Ok(language);
        }

        /// <summary>
        /// Retorna os últimos 100 idiomas
        /// </summary>
        /// <returns></returns>
        [HttpGet("all-last-100")]
        public async Task<IActionResult> GetLanguageLast100()
        {
            try
            {
                var language = await _languageService.GetLastLanguageTop100();
                return Ok(language);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retorna toda lista de Idiomas
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetLanguage()
        {
            try
            {
                var language = await _languageService.GetAllAsync();
                return Ok(language);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///Pesquisa por idioma
        /// </summary>
        /// <returns></returns>
        [HttpGet("search/{languageName}")]
        public async Task<IActionResult> GetLanguageByName(string languageName)
        {
            try
            {
                var language = await _languageService.GetLanguageByNameAsync(languageName);
                return Ok(language);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
