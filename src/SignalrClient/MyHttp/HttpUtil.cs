using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace SignalrClient.MyHttp;

public class HttpUtil
{
      private const long FILE_MAX_SIZE = 100 * 1024 * 1024;

    #region Get

    /// <summary>
    /// Http get请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="parameters"></param>
    /// <param name="bearerToken"></param>
    /// <returns></returns>
    public static async Task<T> GetAsync<T>(string url, Dictionary<string, object> parameters, string bearerToken)
    {
        using (var client = new RestClient(url))
        {
            var request = new RestRequest();
            request.Method = Method.Get;
            request.Timeout = new TimeSpan(0,0,30);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {bearerToken}");
            var queryString = parameters == null ? "{}" : JsonConvert.SerializeObject(parameters);
            request.AddParameter("application/json", queryString,  ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }

            throw new Exception($"Request failed with status code {response.StatusCode} and message: {response.ErrorMessage}");
        }
    }
    
    public static void Get<T>(string url, Dictionary<string, object> parameters, string bearerToken, Action<T> callback)
    {
        try
        {
            using (var client = new RestClient(url))
            {
                var request = new RestRequest();
                request.Method = Method.Get;
                request.Timeout = new TimeSpan(0, 0, 30);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Bearer {bearerToken}");
                var queryString = parameters == null ? "{}" : JsonConvert.SerializeObject(parameters);
                request.AddParameter("application/json", queryString, ParameterType.RequestBody);
                var response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    var result = JsonConvert.DeserializeObject<T>(response.Content);
                    callback.Invoke(result);
                }
            }
        }
        catch
        {
            callback.Invoke(default);
        }
    }

    #endregion

    #region Post

    /// <summary>
    /// Http post请求(无文件)
    /// </summary>
    /// <param name="httpUrl"></param>
    /// <param name="parameters"></param>
    /// <param name="bearerToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<T> PostTaskAsync<T>(string httpUrl, Dictionary<string, object> parameters, string bearerToken)
        => await PostTaskAsync<T>(httpUrl, parameters, bearerToken,null);

    /// <summary>
    /// Http post请求(有文件)
    /// </summary>
    /// <param name="httpUrl"></param>
    /// <param name="parameters"></param>
    /// <param name="bearerToken"></param>
    /// <param name="filePath"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<T> PostFileTaskAsync<T>(string httpUrl, Dictionary<string, object> parameters, string bearerToken, string filePath) 
        => await PostTaskAsync<T>(httpUrl, parameters, bearerToken, filePath);

    /// <summary>
    /// Http post请求
    /// </summary>
    /// <param name="httpUrl"></param>
    /// <param name="parameters"></param>
    /// <param name="bearerToken"></param>
    /// <param name="filePath"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private static async Task<T> PostTaskAsync<T>(string httpUrl, Dictionary<string, object> parameters, string bearerToken, string filePath)
    {
        var uri = new Uri(httpUrl);
        using (var client = new HttpClient())
        {
            if (!string.IsNullOrWhiteSpace(bearerToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            }
            
            StringContent content;
            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                var fileBase64String = await FileToBase64Async(filePath);
                parameters.Add("FileBase64",fileBase64String);
            }
            content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(uri, content);
            result.EnsureSuccessStatusCode();
            var reseponseJson = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(reseponseJson);
        }
    }

    #endregion

    #region Put

       /// <summary>
    /// Http put请求(无文件)
    /// </summary>
    /// <param name="httpUrl"></param>
    /// <param name="parameters"></param>
    /// <param name="bearerToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<T> PutTaskAsync<T>(string httpUrl, Dictionary<string, object> parameters, string bearerToken)
        => await PutAsync<T>(httpUrl, parameters, bearerToken);

    /// <summary>
    /// Http put请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="content"></param>
    /// <param name="bearerToken"></param>
    /// <returns></returns>
    private static async Task<T> PutAsync<T>(string httpUrl, Dictionary<string, object> parameters, string bearerToken)
    {
        using (var client = new RestClient(httpUrl))
        {
            var request = new RestRequest();
            request.Method = Method.Put;
            request.Timeout = new TimeSpan(0,0,30);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {bearerToken}");
            var queryString = parameters == null ? "{}" : JsonConvert.SerializeObject(parameters);
            request.AddParameter("application/json", queryString,  ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }

            throw new Exception($"Request failed with status code {response.StatusCode} and message: {response.ErrorMessage}");
        }
    }

    #endregion

    #region Delete

    /// <summary>
    /// Http delete请求
    /// </summary>
    /// <param name="httpUrl"></param>
    /// <param name="parameters"></param>
    /// <param name="bearerToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<T> DeleteAsync<T>(string httpUrl, Dictionary<string, string> parameters,string bearerToken)
    {
        using (var client = new RestClient(httpUrl))
        {
            var request = new RestRequest();
            request.Method = Method.Delete;
            request.Timeout = new TimeSpan(0,0,30);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {bearerToken}");
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    request.AddQueryParameter(param.Key, param.Value);
                }
            }
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            throw new Exception($"Request failed with status code {response.StatusCode} and message: {response.ErrorMessage}");
        }
    }
    
    #endregion
    
    /// <summary>
    /// 文件转base64字符串
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private static async Task<string> FileToBase64Async(string path)
    {
        var fileInfo = new FileInfo(path);
        var sizeInBytes = fileInfo.Length;
        if (sizeInBytes > FILE_MAX_SIZE)
        {
            throw new Exception("File is too large. File size should be less than 100MB.");
        }
        var bytes = await System.IO.File.ReadAllBytesAsync(path);
        return Convert.ToBase64String(bytes);
    }
}