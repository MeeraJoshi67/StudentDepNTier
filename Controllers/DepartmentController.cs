using DataAccess3.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service3.IRepository;
using StudentDepNTier.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _dep;

        public DepartmentController(IDepartment dep)
        {
            _dep = dep;
        }

        [HttpGet("DepartmentList")]
        public async Task<IActionResult> Students()
        {
            var departmentList = await _dep.GetDepartmentList();
            return Ok(departmentList);

        }
        [HttpPost("AddData")]
        public async Task<string> AddDepartment(Department dep)
        {
            var DepartmentInfo = await _dep.AddDepartment(dep);
            return DepartmentInfo;
        }
        
        [HttpDelete("DeleteById")]
        public async Task<IActionResult>DeleteDepartment(int id)
        {
            var DeletedData = await _dep.DeleteDepartment(id);
            if (DeletedData != null)
                return Ok("Data Is Deleted");
            return BadRequest("Id is wrong");
        }
        [HttpPost("UpdateData")]
        public async Task<IActionResult> UpdateData(Department student)
        {
            var update =await _dep.UpdateDepartment(student);
            if (update != null)
                return Ok(update);
            return BadRequest("not found");


        }
    }
}
