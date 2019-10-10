﻿using flight_planner.core1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flight_planner.core1.Services
{
    public class ServiceResult
    {
        public ServiceResult(int id, bool succeeded)
        {
            Id = id;
            Succeeded = succeeded;
        }

        public ServiceResult(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public ServiceResult(IEnumerable<string> errors)
        {
            Set(errors);
        }

        public int Id { get; }

        public IEntity Entity { get; private set; }

        public bool Succeeded { get; private set; }

        private List<string> errors = new List<string>();

        public ServiceResult Add(IEnumerable<string> errors)
        {
            foreach (string err in errors)
            {
                if (!string.IsNullOrEmpty(err))
                    this.errors.Add(err);
            }

            return this;
        }

        public ServiceResult Set(IEnumerable<string> errors)
        {
            this.errors.Clear();
            Add(errors);

            return this;
        }

        public ServiceResult Set(params string[] errors)
        {
            this.errors.Clear();
            Add(errors);

            return this;
        }

        public ServiceResult Set(bool success)
        {
            Succeeded = success;
            return this;
        }

        public ServiceResult Set(IEntity entity)
        {
            Entity = entity;
            return this;
        }
    }
}
