using Recipes_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Recipes_Web_API.Controllers
{
    public class RecipesController : ApiController
    {
        public List<Recipe> GetList()
        {
            DBservices db = new DBservices();
            return db.GetRecipe();
        }
        [HttpGet]
        [Route("api/recipes/{id}")]
        //Get
        public IHttpActionResult GetRecipe(int id)
        {
            try
            {
                List<Recipe> list = GetList();
                Recipe r = null;
                foreach (var recipe in list)
                {
                    if (id == recipe.id)
                        r = recipe;
                }
                if (r == null)
                {
                    return Content(HttpStatusCode.NotFound, "Recipe with id= " + id + " was not found!");
                }
                return Ok(r);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //Post
        public IHttpActionResult PostRecipe([FromBody] Recipe value)
        {
            try
            {
                DBservices dbSer = new DBservices();
                return Created(new Uri(Request.RequestUri.AbsoluteUri + value.id), dbSer.PostRecipe(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //Put
        public IHttpActionResult PutRecipe([FromBody] Recipe value)
        {
            try
            {
                DBservices dbSer = new DBservices();
                return Content(HttpStatusCode.OK, dbSer.PutRecipe(value));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //Delete
        [HttpDelete]
        [Route("api/recipes/{id}")]
        public IHttpActionResult DeleteRecipe(int id)
        {
            try
            {
                DBservices dbSer = new DBservices();
                return Content(HttpStatusCode.OK, dbSer.DeleteRecipe(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
