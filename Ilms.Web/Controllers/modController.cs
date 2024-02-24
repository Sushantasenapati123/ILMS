using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Ilms.Model.Demo_T_LMS;
using Ilms.Repository.Repositories.Interfaces;
namespace Ilms.Web
{
    public class modController : Controller
    {

        public IConfiguration Configuration;
        private readonly ImodRepository _modRepository;
        private IWebHostEnvironment _hostingEnvironment;
        public modController(IConfiguration configuration, ImodRepository modRepository, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _modRepository = modRepository;

            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Demo_T_LMS()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Demo_T_LMS(Demo_T_LMS TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.ID == 0 || TBL.ID == null)
                {
                    var data = _modRepository.Insert_Demo_T_LMS(TBL);
                    return Json(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = _modRepository.Insert_Demo_T_LMS(TBL);
                    return Json(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet]
        public IActionResult ViewDemo_T_LMS()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_Demo_T_LMS()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<Demo_T_LMS> lst = await _modRepository.Getall_Demo_T_LMS(new Demo_T_LMS());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Json(jsonres);

            }

        }
        [HttpPost]
        public async Task<IActionResult> Search_Demo_T_LMS([FromBody] Demo_T_LMS BL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<Demo_T_LMS> lst = await _modRepository.Search_Demo_T_LMS(BL);
                var jsonres = JsonConvert.SerializeObject(lst);

                return Json(jsonres);

            }

        }

        [HttpDelete]

        public async Task<JsonResult> Delete_Demo_T_LMS(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = _modRepository.Delete_Demo_T_LMS(Id);
                return Json(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet]

        public async Task<JsonResult> GetByID_Demo_T_LMS(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                Demo_T_LMS lst = await _modRepository.GetDemo_T_LMSById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Json(jsonres);
            }
        }
        [HttpPost]
        public async Task<JsonResult> inSertEntireData(Demo_T_LMS objLegal)
        {
            try
            {






                //string CourtId = Request.Form["CourtId"];
                //string Year = Request.Form["Year"];
                //string regid = Request.Form["RegistrationID"];
                //string OptionName = "";
                ////string[] files = objLegal.UploadDocument.Split('\\');
                //objLegal.UploadDocument = FileGuid;

                //============================================================================




                //List<BulkData> bulkdata = new List<BulkData>();
                //BulkData gPartyData = null;
                //for (int i = 0; i < typeids.Length; i++)
                //{
                //    gPartyData = new BulkData();
                //    if (int.TryParse(sequenceIds[i], out int sequenceId))
                //    {
                //        gPartyData.SequenceId = sequenceId;
                //    }
                //    //gPartyData.SequenceId = Convert.ToInt32(sequenceIds[i]);
                //    gPartyData.vchOpponentName = oppnames[i];
                //    gPartyData.intRegistrationID = objLegal.RegistrationID;
                //    if (int.TryParse(typeids[i], out int typeId))
                //    {
                //        gPartyData.intOpponentTypeID = typeId;
                //    }
                //    //gPartyData.intOpponentTypeID = Convert.ToInt32(typeids[i]);
                //    bulkdata.Add(gPartyData);
                //}


                //if (gPartyData.SequenceId != 0 && gPartyData.intOpponentTypeID != 0 && gPartyData.vchOpponentName != "")
                //{
                 await _modRepository.InsertOpponentData(objLegal.ListData);
                //}

                //===============================================================================

                //objLegal.OpponentName = OptionName;
                //var file = _httpContextAccessor.HttpContext.Request.Form.Files["UploadDocument"];
                //if (file != null && file.Length > 0)
                //{
                //    Console.WriteLine("Received file: " + file.FileName);
                //    string filePath = Path.Combine(Guid.NewGuid().ToString(), file.FileName);
                //    string[] result = SplitString(filePath, '\\');
                //    guid = result[0] + Path.GetExtension(file.FileName);
                //    objLegal.UploadDocument = guid;
                //}
                //var Result = await _caseDetailsRepository.UpdateGovtPartySubject(objLegal);
                //if (Result == 2)
                //{
                //    if (file != null)
                //    {
                //        string fileExtension = Path.GetExtension(file.FileName);
                //        await SaveFile(CourtId, Year, regid, file.OpenReadStream(), guid);
                //    }
                //}
                return Json("");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}

