using Microsoft.AspNetCore.Mvc;
using PoisonClassifierWebAPI.Server.Models;
using PoisonClassifierWebAPI.Server.Repositories;

namespace PoisonClassifierWebAPI.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserPageController : ControllerBase
    {
        private ApplicationDBContext context;
        RepositoriesWork repositoriesWork;
        public UserPageController(ApplicationDBContext context)
        {
            this.context = context;
            repositoriesWork = new RepositoriesWork(context);
        }
        public async Task<ActionResult> GetSubClasses()
        {
            return Ok(await repositoriesWork.GetTableSubClasses());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetIndustrialVenom(int id)
        {
            return Ok(await repositoriesWork.GetIndustrialVenom(id));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMedicalVenom(int id)
        {
            return Ok(await repositoriesWork.GetMedicalVenom(id));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubstance(int id)
        {
            return Ok(await repositoriesWork.GetSubClass(id));
        }
        public async Task<ActionResult> GetSubstanceClass()
        {
            return Ok(await repositoriesWork.GetListSubstanceClass());
        }
        [HttpGet("{mainclass}")]
        public async Task<ActionResult> GetSubstanceClassForClass(string mainclass)
        {
            return Ok(await repositoriesWork.GetListSubstanceClassForClass(mainclass));
        }
        [HttpPost]
        public async Task<ActionResult> GetSubstanceClassForChapter(string[] data)
        {
            return Ok(await repositoriesWork.GetListSubstanceClassForChapter(data));
        }
        [HttpPost]
        public async Task<ActionResult> GetSubstanceClassForGroup(string[] data)
        {
            return Ok(await repositoriesWork.GetListSubstanceClassForGroup(data));
        }
        public async Task<ActionResult> GetNatureImpacts()
        {
            return Ok(await repositoriesWork.GetListNatureImpact());
        }
        [HttpGet("{name}")]
        public async Task<ActionResult> GetNIForName(string name)
        {
            return Ok(await repositoriesWork.GetListNatureImpactForName(name));
        }
        [HttpPost]
        public async Task<ActionResult> GetNatureImpactForDescription(string[] data)
        {
            return Ok(await repositoriesWork.GetListNatureImpactForDescription(data));
        }
        public async Task<ActionResult> GetDegreeImpact()
        {
            return Ok(await repositoriesWork.GetListDegreeImpact());
        }
        [HttpGet("{myclass}")]
        public async Task<ActionResult> GetDegreeImpactForClass(string myclass)
        {
            return Ok(await repositoriesWork.GetListDegreeImpactForClass(myclass));
        }
        public async Task<ActionResult> GetOrigion()
        {
            return Ok(await repositoriesWork.GetListOrigion());
        }
        [HttpGet("{group}")]
        public async Task<ActionResult> GetOrigionForGroup(string group)
        {
            return Ok(await repositoriesWork.GetListOrigionForGroup(group));
        }
        public async Task<ActionResult> GetAggregateState()
        {
            return Ok(await repositoriesWork.GetListAggregateState());
        }
        public async Task<ActionResult> GetAggregateStates()
        {
            return Ok(await repositoriesWork.GetAggregateStates());
        }
        public async Task<ActionResult> GetPath()
        {
            return Ok(await repositoriesWork.GetListPath());
        }
        public async Task<ActionResult> GetSymptom()
        {
            return Ok(await repositoriesWork.GetListSymptom());
        }
        public async Task<ActionResult> GetOrgan()
        {
            return Ok(await repositoriesWork.GetListOrgan());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrganOfPath(int id)
        {
            return Ok(await repositoriesWork.GetOrganOfPath(id));
        }
        [HttpPost]
        public async Task<ActionResult> GetPath(int[] pathIdarray)
        {
            return Ok(await repositoriesWork.GetListPath(pathIdarray));
        }
        [HttpPost]
        public async Task<ActionResult> GetSymptom(int[] symptomIdarray)
        {
            return Ok(await repositoriesWork.GetListSymptom(symptomIdarray));
        }
        [HttpPost]
        public async Task<ActionResult> SaveSubstance(SaveData saveData)
        {
            return Ok(await repositoriesWork.SaveSubstance(saveData));
        }
        [HttpPost]
        public async Task<ActionResult> ChangeSubstance(SaveData saveData)
        {
            return Ok(await repositoriesWork.ChangeSubstance(saveData));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> DeleteSubstance(int id)
        {
            return Ok(await repositoriesWork.DeleteSubstance(id));
        }
        [HttpPost]
        public async Task<ActionResult> GetChemicalClassifierExact(string[] data)
        {
            return Ok(await repositoriesWork.GetChemicalClassifierExact(data));
        }
        [HttpPost]
        public async Task<ActionResult> GetChemicalClassifierLax(string[] data)
        {
            return Ok(await repositoriesWork.GetChemicalClassifierLax(data));
        }
        [HttpPost]
        public async Task<ActionResult> GetClassifierSymptomsExact(POSTClassifierSymptoms data)
        {
            return Ok(await repositoriesWork.GetClassifierSymptomsExact(data));
        }
        [HttpPost]
        public async Task<ActionResult> GetClassifierSymptomsLax(POSTClassifierSymptoms data)
        {
            return Ok(await repositoriesWork.GetClassifierSymptomsLax(data));
        }
        [HttpPost]
        public async Task<ActionResult> GetToxicClassifierExact(string[] data)
        {
            return Ok(await repositoriesWork.GetToxicClassifierExact(data));
        }
        [HttpPost]
        public async Task<ActionResult> GetToxicClassifierLax(string[] data)
        {
            return Ok(await repositoriesWork.GetToxicClassifierLax(data));
        }
        [HttpPost]
        public async Task<ActionResult> GetPathClassifierExact(string[] data)
        {
            return Ok(await repositoriesWork.GetPathClassifierExact(data));
        }
        [HttpPost]
        public async Task<ActionResult> GetPathClassifierLax(string[] data)
        {
            return Ok(await repositoriesWork.GetPathClassifierLax(data));
        }
        [HttpPost]
        public async Task<ActionResult> SaveSubstanceClass(SaveData saveData)
        {
            return Ok(await repositoriesWork.SaveSubstanceClass(saveData));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> DeleteSubstanceClass(int id)
        {
            return Ok(await repositoriesWork.DeleteSubstanceClass(id));
        }
        [HttpPost]
        public async Task<ActionResult> SaveNatureImpact(SaveData saveData)
        {
            return Ok(await repositoriesWork.SaveNatureImpact(saveData));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> DeleteNatureImpact(int id)
        {
            return Ok(await repositoriesWork.DeleteNatureImpact(id));
        }
        [HttpPost]
        public async Task<ActionResult> SaveDegreeImpact(SaveData saveData)
        {
            return Ok(await repositoriesWork.SaveDegreeImpact(saveData));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> DeleteDegreeImpact(int id)
        {
            return Ok(await repositoriesWork.DeleteDegreeImpact(id));
        }
        [HttpPost]
        public async Task<ActionResult> SaveOrigion(SaveData saveData)
        {
            return Ok(await repositoriesWork.SaveOrigion(saveData));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> DeleteOrigion(int id)
        {
            return Ok(await repositoriesWork.DeleteOrigion(id));
        }
        [HttpPost]
        public async Task<ActionResult> SaveAggregateState(SaveData saveData)
        {
            return Ok(await repositoriesWork.SaveAggregateState(saveData));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> DeleteAggregateState(int id)
        {
            return Ok(await repositoriesWork.DeleteAggregateState(id));
        }
        [HttpPost]
        public async Task<ActionResult> SaveSymptom(string[] data)
        {
            return Ok(await repositoriesWork.SaveSymptom(data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> DeleteSymptom(int id)
        {
            return Ok(await repositoriesWork.DeleteSymptom(id));
        }
        [HttpPost]
        public async Task<ActionResult> SaveOrgan(string[] data)
        {
            return Ok(await repositoriesWork.SaveOrgan(data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> DeleteOrgan(int id)
        {
            return Ok(await repositoriesWork.DeleteOrgan(id));
        }
        [HttpPost]
        public async Task<ActionResult> SavePath(SavePath savePath)
        {
            return Ok(await repositoriesWork.SavePath(savePath));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> DeletePath(int id)
        {
            return Ok(await repositoriesWork.DeletePath(id));
        }
        [HttpPost]
        public async Task<ActionResult> GetAutorization(string[] data)
        {
            return Ok(await repositoriesWork.GetAutorization(data));
        }
        [HttpGet("{name}")]
        public async Task<ActionResult> GetSearch(string name)
        {
            return Ok(await repositoriesWork.GetSearch(name));
        }
    }
}