﻿using CompanyAPI.DataAccessLayer;
using CompanyAPI.Exceptions;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace CompanyAPI.Controllers
{
    public class CompaniesController : ApiController
    {
        private CompanyEntities db = new CompanyEntities();

        // GET: api/Companies
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<Company>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(HttpResponseException))]
        public IEnumerable<Company> GetCompanies()
        {
            return CompanyDetails.GetAllDuplicateRecords(db);
        }

        // GET: api/Companies/5
        [ResponseType(typeof(Company))]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<Company>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(HttpResponseException))]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Companies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompany(int id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.CompanyId)
            {
                return BadRequest();
            }

            db.Entry(company).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (Exception exception)
            {
                CustomException.HandleException(exception);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Companies             
        [ResponseType(typeof(Company))]
        public IHttpActionResult PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Companies.Add(company);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = company.CompanyId }, company);            
        }

        // DELETE: api/Companies/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            db.Companies.Remove(company);
            db.SaveChanges();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Companies.Count(e => e.CompanyId == id) > 0;
        }
    }
}