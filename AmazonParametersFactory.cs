using System.Collections.Generic;
using System.Linq;

namespace set_aws_headers
{
    public static class AmazonParametersFactory
    {
        public static AmazonPayload Create(string url, string method, string[] headers, string[] querystrings, string[] authorizers)
        {
            var parameters = url.Split('{');
            var pathParameters = parameters?.Where(parameter => parameter.IndexOf('}') != -1)?.Select(parameter => parameter.Substring(0, parameter.IndexOf('}')));
            var payload = new AmazonPayload();
            var headerParameters = headers?.Select(header => new Parameter { In = "header", Name = header, ParameterRequired = true, Type = "string" })?.ToArray();
            var querystringParamteres = querystrings?.Select(querystring => new Parameter { In = "querystring", Name = querystring, ParameterRequired = true, Type = "string" })?.ToArray();

            payload.Parameters = pathParameters?.Select(parameter => new Parameter { In = "path", Name = parameter, ParameterRequired = true, Type = "string" })?.ToArray();

            if (headerParameters?.Any() == true)
            {
                if (payload.Parameters == null)
                {
                    payload.Parameters = new List<Parameter>().ToArray();
                }

                var list = payload.Parameters.ToList();

                list.AddRange(headerParameters);

                payload.Parameters = list.ToArray();
            }

            if (querystringParamteres?.Any() == true)
            {
                if (payload.Parameters == null)
                {
                    payload.Parameters = new List<Parameter>().ToArray();
                }

                var list = payload.Parameters.ToList();

                list.AddRange(querystringParamteres);

                payload.Parameters = list.ToArray();
            }

            var defaultHeaders = new Dictionary<string, AccessControl>
            {
                {
                    "Access-Control-Allow-Origin",
                    new AccessControl
                    {
                        Type = "string"
                    }
                },
                {
                    "Access-Control-Allow-Credentials",
                    new AccessControl
                    {
                        Type = "string"
                    }
                },
                {
                    "Access-Control-Allow-Headers",
                    new AccessControl
                    {
                        Type = "string"
                    }
                },
                {
                    "Access-Control-Allow-Methods",
                    new AccessControl
                    {
                        Type = "string"
                    }
                },
                {
                    "Access-Control-Expose-Headers",
                    new AccessControl
                    {
                        Type = "string"
                    }
                },
                {
                    "Access-Control-Max-Age",
                    new AccessControl
                    {
                        Type = "string"
                    }
                }

            };

            payload.Responses = new Dictionary<string, WelcomeResponse>
            {
                {
                    "200",
                    new WelcomeResponse
                    {
                        Description = "200 response",
                        Headers = defaultHeaders
                    }
                },
                {
                    "201",
                    new WelcomeResponse
                    {
                        Description = "201 response",
                        Headers = defaultHeaders
                    }
                },
                {
                    "202",
                    new WelcomeResponse
                    {
                        Description = "202 response",
                        Headers = defaultHeaders
                    }
                },
                {
                    "204",
                    new WelcomeResponse
                    {
                        Description = "204 response",
                        Headers = defaultHeaders
                    }
                },
                {
                    "400",
                    new WelcomeResponse
                    {
                        Description = "400 response",
                        Headers = defaultHeaders
                    }
                },
                {
                    "401",
                    new WelcomeResponse
                    {
                        Description = "401 response",
                        Headers = defaultHeaders
                    }
                },
                {
                    "404",
                    new WelcomeResponse
                    {
                        Description = "404 response",
                        Headers = defaultHeaders
                    }
                },
                {
                    "500",
                    new WelcomeResponse
                    {
                        Description = "500 response",
                        Headers = defaultHeaders
                    }
                },
            };

            var security = new Dictionary<string, object[]>();

            foreach (var authorizer in authorizers)
            {
                security.Add(authorizer, Enumerable.Empty<object>().ToArray());
            }

            payload.Security = new List<Dictionary<string, object[]>> { security };

            payload.XAmazonApigatewayIntegration = new XAmazonApigatewayIntegration
            {
                ConnectionId = "${stageVariables.VPC_LINK}",
                ConnectionType = "VPC_LINK",
                HttpMethod = method,
                PassthroughBehavior = "when_no_match",
                Uri = url,
                Type = "http_proxy",
                Responses = new Dictionary<string, XAmazonApigatewayIntegrationResponse>
                {
                    {
                        "default",
                        new XAmazonApigatewayIntegrationResponse
                        {
                            StatusCode = "200",
                            ResponseParameters = new ResponseParameters
                            {
                                MethodResponseHeaderAccessControlAllowHeaders = "'*'",
                                MethodResponseHeaderAccessControlAllowMethods = "'*'",
                                MethodResponseHeaderAccessControlAllowOrigin = "'*'"
                            }
                        }
                    },
                    {
                        "201",
                        new XAmazonApigatewayIntegrationResponse
                        {
                            StatusCode = "201",
                            ResponseParameters = new ResponseParameters
                            {
                                MethodResponseHeaderAccessControlAllowHeaders = "'*'",
                                MethodResponseHeaderAccessControlAllowMethods = "'*'",
                                MethodResponseHeaderAccessControlAllowOrigin = "'*'"
                            }
                        }
                    },
                    {
                        "202",
                        new XAmazonApigatewayIntegrationResponse
                        {
                            StatusCode = "202",
                            ResponseParameters = new ResponseParameters
                            {
                                MethodResponseHeaderAccessControlAllowHeaders = "'*'",
                                MethodResponseHeaderAccessControlAllowMethods = "'*'",
                                MethodResponseHeaderAccessControlAllowOrigin = "'*'"
                            }
                        }
                    },
                    {
                        "204",
                        new XAmazonApigatewayIntegrationResponse
                        {
                            StatusCode = "204",
                            ResponseParameters = new ResponseParameters
                            {
                                MethodResponseHeaderAccessControlAllowHeaders = "'*'",
                                MethodResponseHeaderAccessControlAllowMethods = "'*'",
                                MethodResponseHeaderAccessControlAllowOrigin = "'*'"
                            }
                        }
                    },
                    {
                        "400",
                        new XAmazonApigatewayIntegrationResponse
                        {
                            StatusCode = "400",
                            ResponseParameters = new ResponseParameters
                            {
                                MethodResponseHeaderAccessControlAllowHeaders = "'*'",
                                MethodResponseHeaderAccessControlAllowMethods = "'*'",
                                MethodResponseHeaderAccessControlAllowOrigin = "'*'"
                            }
                        }
                    },
                    {
                        "401",
                        new XAmazonApigatewayIntegrationResponse
                        {
                            StatusCode = "401",
                            ResponseParameters = new ResponseParameters
                            {
                                MethodResponseHeaderAccessControlAllowHeaders = "'*'",
                                MethodResponseHeaderAccessControlAllowMethods = "'*'",
                                MethodResponseHeaderAccessControlAllowOrigin = "'*'"
                            }
                        }
                    },
                    {
                        "404",
                        new XAmazonApigatewayIntegrationResponse
                        {
                            StatusCode = "404",
                            ResponseParameters = new ResponseParameters
                            {
                                MethodResponseHeaderAccessControlAllowHeaders = "'*'",
                                MethodResponseHeaderAccessControlAllowMethods = "'*'",
                                MethodResponseHeaderAccessControlAllowOrigin = "'*'"
                            }
                        }
                    },
                    {
                        "500",
                        new XAmazonApigatewayIntegrationResponse
                        {
                            StatusCode = "500",
                            ResponseParameters = new ResponseParameters
                            {
                                MethodResponseHeaderAccessControlAllowHeaders = "'*'",
                                MethodResponseHeaderAccessControlAllowMethods = "'*'",
                                MethodResponseHeaderAccessControlAllowOrigin = "'*'"
                            }
                        }
                    },
                }
            };

            return payload;
        }
    }
}
