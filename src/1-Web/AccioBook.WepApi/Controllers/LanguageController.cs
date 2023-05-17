using AccioBook.Domain.Entities;
using AccioBook.WepApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccioBook.WepApi.Controllers
{
    public class LanguageController
    {

        ///// <summary>
        ///// Insere um nova linguagem no banco.
        ///// </summary>     
        ///// <returns></returns>

        //[HttpPost("insertLanguage")]
        //public async Task<IActionResult> InsertLanguage(LanguageModel languageArgs)
        //{
        //    var language = new Language();

        //    language.Id = languageArgs.Id;
        //    language.Name = languageArgs.Name;

        //    language = await _languageService.AddAndSaveAsync(language);

        //    if (language.Id != default(int))
        //    {
        //        return Ok(language);
        //    }

        //    return BadRequest();
        //}

        ///// <summary>
        ///// Deleta uma linguagem do banco
        ///// </summary>
        ///// <returns></returns>
        //[HttpDelete("deleteLanguage")]
        //public async Task<IActionResult> DeleteLanguage(LanguageModel languageArgs)
        //{
        //    var language = new Language();

        //    language.Id = languageArgs.Id;

        //    try
        //    {
        //        await _languageService.DeleteAsync(language.Id);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        ///// <summary>
        ///// Atualiza uma linguagem existente no banco.
        ///// </summary>     
        ///// <returns></returns>

        //[HttpPut("updateLanguage")]
        //public async Task<IActionResult> UpdateLanguage(LanguageModel languageArgs)
        //{
        //    var language = new Language();

        //    language.Id = languageArgs.Id;
        //    language.Name = languageArgs.Name;

        //    try
        //    {
        //        await _languageService.UpdateAsync(language);
        //        return Ok(language);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
