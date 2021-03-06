﻿using DiplomaDataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace OptionsWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ChoicesController : ApiController
    {
        private DiplomaContext db = new DiplomaContext();

        // Chart
        public JToken GetAllChoices()
        {
            IEnumerable<Choice> choices = db.Choices.Include(c => c.FirstOption).Include(c => c.FourthOption).Include(c => c.SecondOption).Include(c => c.ThirdOption).Include(c => c.YearTerm);

            var yearterms = db.YearTerms.ToArray();
            var options = db.Options.Select(c => c.Title).ToArray();
            var optionCode = db.Options.Select(c => c.OptionId).ToList();

            JObject obj = new JObject();

            JArray first, second, third, fourth, optionsJ = new JArray();

            foreach (var option in options) { optionsJ.Add(option); } // string[] options

            // foreach term
            foreach (var item in yearterms)
            {
                var yeartermRecords = choices.Where(c => c.YearTermId == item.YearTermId);

                first = new JArray();
                second = new JArray();
                third = new JArray();
                fourth = new JArray();

                var i = 0;

                var _1_count = new int[optionCode.Count];
                var _2_count = new int[optionCode.Count];
                var _3_count = new int[optionCode.Count];
                var _4_count = new int[optionCode.Count];

                // records of that term
                foreach (var record in yeartermRecords)
                {
                    int _1 = record.FirstChoiceOptionId ?? 0;
                    int _2 = record.SecondChoiceOptionId ?? 0;
                    int _3 = record.ThirdChoiceOptionId ?? 0;
                    int _4 = record.FourthChoiceOptionId ?? 0;

                    foreach (var option in optionCode)
                    {
                        if (option == _1)
                        {
                            _1_count[optionCode.IndexOf(option)]++;
                        }
                        if (option == _2)
                        {
                            _2_count[optionCode.IndexOf(option)]++;
                        }
                        if (option == _3)
                        {
                            _3_count[optionCode.IndexOf(option)]++;
                        }
                        if (option == _4)
                        {
                            _4_count[optionCode.IndexOf(option)]++;
                        }
                    }
                    i++;
                }

                first.Add(_1_count);
                second.Add(_2_count);
                third.Add(_3_count);
                fourth.Add(_4_count);

                JObject choiceArrays = new JObject();

                choiceArrays.Add("first", first);
                choiceArrays.Add("second", second);
                choiceArrays.Add("third", third);
                choiceArrays.Add("fourth", fourth);
                choiceArrays.Add("count", i);

                obj.Add(item.YearTermId.ToString(), choiceArrays);
            }

            obj.Add("options", optionsJ);
            obj.Add("numYearTerms", yearterms.Count());
            return obj;

        }

        [System.Web.Http.Route("GetDataForChoiceForm/{username}")]
        public JToken GetDataForChoiceForm(string username)
        {
            JObject obj = new JObject();
            obj.Add("options", JsonConvert.SerializeObject(db.Options.Select(n => n.Title).ToList()));
            obj.Add("yearterms", JsonConvert.SerializeObject(db.YearTerms.ToList()));
            obj.Add("prevchoices", JsonConvert.SerializeObject(db.Choices.Where(c => c.StudentId == username)));
            return obj;
        }

        [ResponseType(typeof(Choice))]
        public IHttpActionResult PostChoice(Choice choice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Choices.Add(choice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = choice.ChoiceId }, choice);
        }

        [System.Web.Http.Route("GetALLChoicesForTable")]
        public JToken GetALLChoicesForTable()
        {
            JObject obj = new JObject();
            obj.Add("data", JsonConvert.SerializeObject(db.Choices.ToArray()));
            obj.Add("options", JsonConvert.SerializeObject(db.Options.Select(c => c.Title)));
            obj.Add("options-id", JsonConvert.SerializeObject(db.Options.Select(c => c.OptionId)));
            obj.Add("yearterms-term", JsonConvert.SerializeObject(db.YearTerms.Select(c => c.Term)));
            obj.Add("yearterms-year", JsonConvert.SerializeObject(db.YearTerms.Select(c => c.Year)));
            obj.Add("yearterms-id", JsonConvert.SerializeObject(db.YearTerms.Select(c => c.YearTermId)));
            return obj;
        }
    }
}
