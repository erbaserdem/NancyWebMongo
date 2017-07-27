using Nancy;
using Nancy.ModelBinding;
using NancyAspNetHost1.Service;

namespace NancyAspNetHost1.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };


            Get["/register"] = parameters =>
            {
                return View["register"];
            };


            Get["/users/id/{value}"] = parameters => View["ViewUser",new Find().CheckForExistingId(parameters.value)];


        }
    }
}