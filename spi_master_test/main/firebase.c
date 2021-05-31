
#include "firebase.h"

extern float voltage_value_test[];

esp_err_t clientEventHandler(esp_http_client_event_t *evt)
{
    switch (evt->event_id)
    {
    case HTTP_EVENT_ERROR:
        ESP_LOGI(TAG_HTTP, "HTTP_EVENT_ERROR");
        break;
    case HTTP_EVENT_ON_CONNECTED:
        ESP_LOGI(TAG_HTTP, "HTTP_EVENT_ON_CONNECTED");
        break;
    case HTTP_EVENT_HEADER_SENT:
        ESP_LOGI(TAG_HTTP, "HTTP_EVENT_HEADER_SENT");
        break;
    case HTTP_EVENT_ON_HEADER:
        ESP_LOGI(TAG_HTTP, "HTTP_EVENT_ON_HEADER");
        printf("%.*s", evt->data_len, (char *)evt->data);
        break;
    case HTTP_EVENT_ON_DATA:
        ESP_LOGI(TAG_HTTP, "HTTP_EVENT_ON_DATA Len=%d", evt->data_len);
        printf("%.*s\n", evt->data_len, (char *)evt->data);
        // if config buffer read in esp_http_client_config_t
        if (evt->user_data)
        {
            memcpy(evt->user_data, evt->data, evt->data_len);
        }
        //if dont use  your variable
        else
        {
            // if (buffer_read == NULL)
            // {
            //     buffer_read = (char *)malloc(esp_http_client_get_content_length(evt->client));
            //     buffer_read_index = 0;
            //     // if can not allocate
            //     if (buffer_read == NULL)
            //     {
            //         ESP_LOGE(TAG_HTTP, "Failed to allocate memory for output buffer");
            //         return ESP_FAIL;
            //     }
            // }
            // memcpy(buffer_read + buffer_read_index, evt->data, evt->data_len);
        }
        //buffer_read_index += evt->data_len;
        break;
    case HTTP_EVENT_ON_FINISH:
        ESP_LOGI(TAG_HTTP, "HTTP_EVENT_ON_FINISH");
        break;
    case HTTP_EVENT_DISCONNECTED:
        ESP_LOGI(TAG_HTTP, "HTTP_EVENT_DISCONNECTED");
        break;
    }
    return ESP_OK;
}
// void http_get(char *url)
// {
//     //create an esp_http_client by pass into this function with the
//     //esp_http_client_config_t configurations
//     esp_http_client_config_t clientConfig = {
//         .url = url,
//         .method = HTTP_METHOD_GET,
//         .event_handler = clientEventHandler};
//     // pass client config to function esp_http_client_init
//     // to create a client (esp_http_client_handle_t)
//     esp_http_client_handle_t client = esp_http_client_init(&clientConfig);
//     // This function esp_http_client_performs all operations of the esp_http_client
//     // opening the connection, sending data, downloading data and closing the connection
//     esp_err_t err = esp_http_client_perform(client);
//     if (err == ESP_OK)
//     {
//         int status_http_request = esp_http_client_get_status_code(client);
//         int length_http_request = esp_http_client_get_content_length(client);
//         ESP_LOGI(TAG_HTTP, "HTTP GET status = %d, content_length = %d",
//                  status_http_request,
//                  length_http_request);
//         ESP_LOGI(TAG_HTTP, "HTTP GET DATA");
//     }
//     else
//     {
//         ESP_LOGE(TAG_HTTP, "HTTP GET request failed: %s", esp_err_to_name(err));
//     }
//     esp_http_client_cleanup(client);
// }

// void http_post(char *url)
// {
//     // POST
//     esp_http_client_config_t clientConfig = {
//         .url = url,
//         .method = HTTP_METHOD_POST,
//         .event_handler = clientEventHandler};
//     // pass client config to function esp_http_client_init
//     // to create a client (esp_http_client_handle_t)
//     esp_http_client_handle_t client = esp_http_client_init(&clientConfig);
  
//     const char *post_data = create_battery_voltage(voltage_value_test,8);
//     printf("%s \n",post_data);  
//     esp_http_client_set_header(client, "Content-Type", "text/plain");
//     esp_http_client_set_post_field(client, post_data, strlen(post_data));
//     int err = esp_http_client_perform(client);
//     if (err == ESP_OK)
//     {
//         ESP_LOGI(TAG_HTTP, "HTTP POST Status = %d, content_length = %d",
//                  esp_http_client_get_status_code(client),
//                  esp_http_client_get_content_length(client));
//         for(int i =0 ;i < buffer_read_index ;i++){
//             printf("%c",buffer_read[i]);
//         }
//         printf("\n");
//     }
//     else
//     {
//         ESP_LOGE(TAG_HTTP, "HTTP POST request failed: %s", esp_err_to_name(err));
//     }
// }

// void http_delete(char* url){
//     esp_http_client_config_t clientConfig = {
//         .url = url,
//         .method = HTTP_METHOD_DELETE,
//         .event_handler = clientEventHandler};
//     // pass client config to function esp_http_client_init
//     // to create a client (esp_http_client_handle_t)
//     esp_http_client_handle_t client = esp_http_client_init(&clientConfig);
//     int err = esp_http_client_perform(client);
//     if (err == ESP_OK) {
//         ESP_LOGI(TAG_HTTP, "HTTP DELETE Status = %d, content_length = %d",
//                 esp_http_client_get_status_code(client),
//                 esp_http_client_get_content_length(client));
//     } else {
//         ESP_LOGE(TAG_HTTP, "HTTP DELETE request failed: %s", esp_err_to_name(err));
//     }
// }

void http_put(char *url, const char* data)
{
    // POST
    ESP_LOGI(TAG_HTTP,"START POST");
    esp_http_client_config_t clientConfig = {
        .url = url,
        .method = HTTP_METHOD_PUT,
        .event_handler = clientEventHandler};
    // pass client config to function esp_http_client_init
    // to create a client (esp_http_client_handle_t)
    esp_http_client_handle_t client = esp_http_client_init(&clientConfig);
    //printf("%s \n",data);  
    esp_http_client_set_header(client, "Content-Type", "text/plain");
    esp_http_client_set_post_field(client, data, strlen(data));
    int err = esp_http_client_perform(client);
    if (err == ESP_OK)
    {
        ESP_LOGI(TAG_HTTP, "HTTP POST Status = %d, content_length = %d",
                 esp_http_client_get_status_code(client),
                 esp_http_client_get_content_length(client));
        // for(int i =0 ;i < buffer_read_index ;i++){
        //     printf("%c",buffer_read[i]);
        // }
        // printf("\n");
    }
    else
    {
        ESP_LOGE(TAG_HTTP, "HTTP POST request failed: %s", esp_err_to_name(err));
    }
    esp_http_client_cleanup(client);
}