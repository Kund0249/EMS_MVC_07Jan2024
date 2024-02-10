using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS_MVC_07Jan2024.Controllers
{

    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }

    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
    }

    public class StateRepository
    {
        private readonly String CS = string.Empty;
        public StateRepository()
        {
            CS = System.Configuration.ConfigurationManager.
                ConnectionStrings["DBCon"].ConnectionString;
        }
        public List<State> GetStates
        {
            get
            {
                List<State> States = new List<State>();

                using (SqlConnection con = new SqlConnection(CS))
                {
                    string Query = "Select * from TSTATE";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            States.Add(new State()
                            {
                                StateId = Convert.ToInt32(reader["StateId"]),
                                StateName = Convert.ToString(reader["StateName"])
                            });
                        }
                    }
                    con.Close();
                }

                return States;
            }
        }
    }

    public class CityRepository
    {
        private readonly String CS = string.Empty;
        public CityRepository()
        {
            CS = System.Configuration.ConfigurationManager.
                ConnectionStrings["DBCon"].ConnectionString;
        }
        public List<City> GetCities(int StateId = 0)
        {

            List<City> Cities = new List<City>();

            if (StateId == 0)
                return Cities;

            using (SqlConnection con = new SqlConnection(CS))
            {
                string Query = "Select * from TCITY where StateId = " + StateId;
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Cities.Add(new City()
                        {
                            CityId = Convert.ToInt32(reader["CityId"]),
                            CityName = Convert.ToString(reader["CityName"]),
                            StateId = Convert.ToInt32(reader["StateId"])
                        });
                    }
                }
                con.Close();
            }

            return Cities;

        }
    }

    public class WrapperStateCity
    {
        public int selectedState { get; set; }
        public int SelectedCity { get; set; }

        //public Employee employee { get; set; }
        //public Address address { get; set; }
        public List<State> States { get; set; }
        public List<City> cities { get; set; }
    }

    [AllowAnonymous]
    public class CasCadinDemoController : Controller
    {
        // GET: CasCadinDemo

        private readonly StateRepository stateRepository;
        private readonly CityRepository cityRepository;

        public CasCadinDemoController()
        {
            stateRepository = new StateRepository();
            cityRepository = new CityRepository();
        }

        [Route("Example")]
        public ActionResult Index()
        {
            WrapperStateCity wrapper = new WrapperStateCity()
            {
                selectedState = 0,
                SelectedCity = 0,
                States = stateRepository.GetStates,
                cities = cityRepository.GetCities()
            };
            return View(wrapper);
        }

        [HttpPost]
        public ActionResult Index(WrapperStateCity model)
        {
            WrapperStateCity wrapper = new WrapperStateCity()
            {
                selectedState = model.selectedState,
                SelectedCity = model.SelectedCity,
                States = stateRepository.GetStates,
                cities = cityRepository.GetCities(model.selectedState)
            };
            return View(wrapper);
        }

        [HttpGet]
        public JsonResult GetCity(int StateId)
        {
            //LINQ
            //TRACING
            //JQUERY & AJAX
            var data = cityRepository.GetCities(StateId);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}
