﻿namespace Superscribe.Engine
{
    using System;

    using Superscribe.Models;
    using Superscribe.Models.Filters;
    using Superscribe.Utils;

    public class RouteEngine : IRouteEngine
    {
        private readonly GraphNode @base = new GraphNode();

        public RouteEngine(SuperscribeOptions options)
        {
            this.Config = options;
        }

        public GraphNode Base
        {
            get
            {
                return this.@base;
            }
        }

        public SuperscribeOptions Config { get; private set; }

        public IRouteWalker Walker()
        {
            return this.Config.RouteWalkerFactory(this.Base);
        }

        public GraphNode Route(string routeTemplate)
        {
            var node = this.Config.StringRouteParser.MapToGraph(routeTemplate);
            if (node != null)
            {
                this.Base.Zip(node.Base());
                return node;
            }

            return null;
        }

        public GraphNode Route(string routeTemplate, Func<dynamic, object> func)
        {
            return this.Route(routeTemplate, func, new Filter[] { });
        }

        public GraphNode Route(string routeTemplate, Func<dynamic, object> func, params Filter[] filters)
        {
            var finalNode = this.Base;
            var node = this.Config.StringRouteParser.MapToGraph(routeTemplate);

            if (node != null)
            {
                this.Base.Zip(node.Base());
                finalNode = node;
            }

            finalNode.FinalFunctions.Add(new ExclusiveFinalFunction(func, filters));

            return node;
        }

        public GraphNode Route(GraphNode config)
        {
            this.Base.Zip(config.Base());
            return config;
        }

        public GraphNode Route(GraphNode config, Func<dynamic, object> func)
        {
            config.FinalFunctions.Add(new ExclusiveFinalFunction { Function = func });
            this.Base.Zip(config.Base());

            return config;
        }

        public GraphNode Route(GraphNode config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Route(Func<RouteGlue, GraphNode> config)
        {
            var leaf = config(new RouteGlue());
            this.Base.Zip(leaf.Base());
            return leaf;
        }

        public GraphNode Route(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func)
        {
            var leaf = config(new RouteGlue());
            leaf.FinalFunctions.Add(new ExclusiveFinalFunction { Function = func });
            this.Base.Zip(leaf.Base());

            return leaf;
        }

        public GraphNode Route(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Get(string routeTemplate, Func<dynamic, object> func)
        {
            return this.MethodNode(routeTemplate, func, "GET");
        }

        public GraphNode Get(GraphNode leaf, Func<dynamic, object> func)
        {
            return this.MethodNode(leaf, func, "GET");
        }

        public GraphNode Get(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func)
        {
            return this.MethodNode(config, func, "GET");
        }

        public GraphNode Get(string routeTemplate, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Get(GraphNode config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Get(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Post(string routeTemplate, Func<dynamic, object> func)
        {
            return this.MethodNode(routeTemplate, func, "POST");
        }

        public GraphNode Post(GraphNode leaf, Func<dynamic, object> func)
        {
            return this.MethodNode(leaf, func, "POST");
        }

        public GraphNode Post(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func)
        {
            return this.MethodNode(config, func, "POST");
        }

        public GraphNode Post(string routeTemplate, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Post(GraphNode config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Post(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Put(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Patch(string routeTemplate, Func<dynamic, object> func)
        {
            return this.MethodNode(routeTemplate, func, "PATCH");
        }

        public GraphNode Patch(GraphNode leaf, Func<dynamic, object> func)
        {
            return this.MethodNode(leaf, func, "PATCH");
        }

        public GraphNode Patch(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func)
        {
            return this.MethodNode(config, func, "PATCH");
        }

        public GraphNode Patch(string routeTemplate, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Patch(GraphNode config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Patch(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Put(string routeTemplate, Func<dynamic, object> func)
        {
            return this.MethodNode(routeTemplate, func, "PUT");
        }

        public GraphNode Put(GraphNode leaf, Func<dynamic, object> func)
        {
            return this.MethodNode(leaf, func, "PUT");
        }

        public GraphNode Put(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func)
        {
            return this.MethodNode(config, func, "PUT");
        }

        public GraphNode Put(GraphNode config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Delete(string routeTemplate, Func<dynamic, object> func)
        {
            return this.MethodNode(routeTemplate, func, "DELETE");
        }

        public GraphNode Delete(GraphNode leaf, Func<dynamic, object> func)
        {
            return this.MethodNode(leaf, func, "DELETE");
        }

        public GraphNode Delete(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func)
        {
            return this.MethodNode(config, func, "DELETE");
        }

        public GraphNode Delete(string routeTemplate, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Delete(GraphNode config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        public GraphNode Delete(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func, params Filter[] filters)
        {
            throw new NotImplementedException();
        }

        private GraphNode MethodNode(string routeTemplate, Func<dynamic, object> func, string method)
        {
            var finalNode = this.Base;
            var node = this.Config.StringRouteParser.MapToGraph(routeTemplate);

            if (node != null)
            {
                this.Base.Zip(node.Base());
                finalNode = node;
            }

            finalNode.FinalFunctions.Add(new ExclusiveFinalFunction(func, new MethodFilter(method)));
            return node;
        }

        private GraphNode MethodNode(GraphNode leaf, Func<dynamic, object> func, string method)
        {
            leaf.FinalFunctions.Add(new ExclusiveFinalFunction(func, new MethodFilter(method)));

            this.Base.Zip(leaf.Base());
            return leaf;
        }

        private GraphNode MethodNode(Func<RouteGlue, GraphNode> config, Func<dynamic, object> func, string method)
        {
            var leaf = config(new RouteGlue());
            leaf.FinalFunctions.Add(new ExclusiveFinalFunction(func, new MethodFilter(method)));

            this.Base.Zip(leaf.Base());
            return leaf;
        }
    }
}
