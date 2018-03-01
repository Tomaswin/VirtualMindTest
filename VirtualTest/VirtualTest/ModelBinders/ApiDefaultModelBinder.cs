﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMCoreNET.Serialization;

namespace VirtualTest.ModelBinders
{
    public class ApiDefaultModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;

            var adapter = GetAdaper(request.ContentType);

            if (adapter == null)
            {
                return base.BindModel(controllerContext, bindingContext);
            }
            
            request.InputStream.Position = 0;
            return adapter.Deserialize(request.InputStream, bindingContext.ModelMetadata.ModelType);

        }


        private SerializationAdapter GetAdaper(string contentType)
        {
            SerializationAdapter adapter = null;

            if (contentType.Contains("json"))
            {
                adapter = SerializationAdapter.GetAdapter(SerializationAdapterType.JSON);

            }

            return adapter;
        }
    }
}