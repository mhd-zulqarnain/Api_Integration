﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiSleepingPatener.Models;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ApiSleepingPatener.Controllers
{
    [System.Web.Mvc.RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        // GET: User

         List<User1> list = new List<User1> {
                new User1() {
                    UId = 1,
                    Name ="Zulqarnain",
                    Email = "z@g.com",
                    Password="test"
                },
                new User1() {
                    UId = 2,
                    Name ="twt",
                    Email = "t@g.com",
                    Password="test"
                },
            };
       

        public IEnumerable<User1> Get()
        {
           
            return list;
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetById/{id}")]
        public User1 GetById(int id)
        {
            return list[id];
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("GetPassword/{id}")]
        public string GetPassword(int id)
        {
            return "Password "+list[id].Password;
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Route("NewUser")]
        public IHttpActionResult NewUser([FromBody]User1 value)
        {
            list.Add(value);
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["mypc"].ConnectionString);
            if (connect.State != ConnectionState.Open)
                connect.Open();
            SqlCommand cmds;
            cmds = new SqlCommand("insert into BonusSetting values (2,'hello world',23)", connect);
            cmds.ExecuteNonQuery();
            connect.Close();
            return Ok(1);
        }

        //public string getEmail(int id)
        //{
        //    return "Email " + list[id].Email;
        //}

    }
}