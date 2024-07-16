using LogKPI.Models;
using System;
using System.Linq;
using System.Data;
using System.Web.Mvc;
using LogKPI.Data;

namespace kpi_peformance.Controllers
{
    public class HomeController : Controller
    {
        private readonly KPIContext db = new KPIContext();
        public ActionResult Index(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var dataKpi = db.TB_KPIs.OrderByDescending(date => date.Ship_date).ToList();
            var data = new CombineModel
            {
                ListKPI = dataKpi, // Use the filtered data for display
                CreateKPI = new TB_KPI()
            };

            return View(data);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                // Temukan data yang akan dihapus dari database
                var dataUser = db.TB_KPIs.Find(id);
                if (dataUser != null)
                    db.TB_KPIs.Remove(dataUser);

                db.SaveChanges();
                return RedirectToAction("Index"); // Redirect kembali ke tampilan Index setelah berhasil menghapus data
            }
            catch (Exception)
            {
                // Handle Error if this failed to deleted
                return RedirectToAction("Index"); // Anda dapat memilih tindakan yang sesuai jika terjadi kesalahan
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}