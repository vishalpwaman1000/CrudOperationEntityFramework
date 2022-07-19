using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationInEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        private readonly ICrudOperationSL _crudOperationSL;
        public CrudOperationController(ICrudOperationSL crudOperationSL)
        {
            _crudOperationSL = crudOperationSL;
        }

        [HttpPost]
        public async Task<ActionResult> InsertUserDetail([FromForm] InsertUserDetailRequest request)
        {
            InsertUserDetailResponse response = new InsertUserDetailResponse();
            try
            {
                response = await _crudOperationSL.InsertUserDetail(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> GetBook()
        {
            GetBookResponse response = new GetBookResponse();
            try
            {
                response = await _crudOperationSL.GetBook();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUserDetails([FromForm] UpdateUserDetailRequest request)
        {
            UpdateUserDetailsResponse response = new UpdateUserDetailsResponse();
            try
            {
                response = await _crudOperationSL.UpdateUserDetails(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook([FromQuery]int UserID)
        {
            DeleteBookResponse response = new DeleteBookResponse();
            try
            {
                response = await _crudOperationSL.DeleteBook(UserID);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
