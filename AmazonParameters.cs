using Newtonsoft.Json;
using System.Collections.Generic;

namespace set_aws_headers
{
    public partial class AmazonPayload
    {
        [JsonProperty("parameters")]
        public Parameter[] Parameters { get; set; }

        [JsonProperty("responses")]
        public Dictionary<string, WelcomeResponse> Responses { get; set; }

        [JsonProperty("security")]
        public List<Dictionary<string, object[]>> Security { get; set; }

        [JsonProperty("x-amazon-apigateway-integration")]
        public XAmazonApigatewayIntegration XAmazonApigatewayIntegration { get; set; }
    }

    public partial class Parameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("in")]
        public string In { get; set; }

        [JsonProperty("required")]
        public bool ParameterRequired { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class WelcomeResponse
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("headers")]
        public Dictionary<string, AccessControl> Headers { get; set; }
    }

    public partial class AccessControl
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class XAmazonApigatewayIntegration
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("responses")]
        public Dictionary<string, XAmazonApigatewayIntegrationResponse> Responses { get; set; }

        [JsonProperty("passthroughBehavior")]
        public string PassthroughBehavior { get; set; }

        [JsonProperty("connectionType")]
        public string ConnectionType { get; set; }

        [JsonProperty("connectionId")]
        public string ConnectionId { get; set; }

        [JsonProperty("httpMethod")]
        public string HttpMethod { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class XAmazonApigatewayIntegrationResponse
    {
        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("responseParameters")]
        public ResponseParameters ResponseParameters { get; set; }
    }

    public partial class ResponseParameters
    {
        [JsonProperty("method.response.header.Access-Control-Allow-Methods")]
        public string MethodResponseHeaderAccessControlAllowMethods { get; set; }

        [JsonProperty("method.response.header.Access-Control-Allow-Headers")]
        public string MethodResponseHeaderAccessControlAllowHeaders { get; set; }

        [JsonProperty("method.response.header.Access-Control-Allow-Origin")]
        public string MethodResponseHeaderAccessControlAllowOrigin { get; set; }
    }
}
