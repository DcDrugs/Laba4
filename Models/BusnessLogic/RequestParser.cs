using System;
using DataAccess;
using Requests;

namespace BusinessLogic
{
    public class RequestParser
    {
        SQLLoader _loader;

        public RequestParser(RequestOpen request)
        {
            _loader = new SQLLoader(request);
        }

        public TablesManager LoadRequest(RequestTask request)
        {
           return new TablesManager(_loader.Request(request), request.GetTableName());
        }
    }

}
