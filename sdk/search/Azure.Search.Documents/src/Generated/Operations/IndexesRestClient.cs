// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
    internal partial class IndexesRestClient
    {
        private string endpoint;
        private string apiVersion;
        private ClientDiagnostics clientDiagnostics;
        private HttpPipeline pipeline;

        /// <summary> Initializes a new instance of IndexesRestClient. </summary>
        public IndexesRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion = "2019-05-06-Preview")
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }
            if (apiVersion == null)
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            this.endpoint = endpoint;
            this.apiVersion = apiVersion;
            this.clientDiagnostics = clientDiagnostics;
            this.pipeline = pipeline;
        }

        internal HttpMessage CreateCreateRequest(Guid? xMsClientRequestId, SearchIndex index)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/indexes", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (xMsClientRequestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", xMsClientRequestId.Value);
            }
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(index);
            request.Content = content;
            return message;
        }

        /// <summary> Creates a new search index. </summary>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="index"> The definition of the index to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SearchIndex>> CreateAsync(Guid? xMsClientRequestId, SearchIndex index, CancellationToken cancellationToken = default)
        {
            if (index == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.Create");
            scope.Start();
            try
            {
                using var message = CreateCreateRequest(xMsClientRequestId, index);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            SearchIndex value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = SearchIndex.DeserializeSearchIndex(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new search index. </summary>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="index"> The definition of the index to create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SearchIndex> Create(Guid? xMsClientRequestId, SearchIndex index, CancellationToken cancellationToken = default)
        {
            if (index == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.Create");
            scope.Start();
            try
            {
                using var message = CreateCreateRequest(xMsClientRequestId, index);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 201:
                        {
                            SearchIndex value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = SearchIndex.DeserializeSearchIndex(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateListRequest(string select, Guid? xMsClientRequestId)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/indexes", false);
            if (select != null)
            {
                uri.AppendQuery("$select", select, true);
            }
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (xMsClientRequestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", xMsClientRequestId.Value);
            }
            return message;
        }

        /// <summary> Lists all indexes available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the index definitions to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<ListIndexesResult>> ListAsync(string select, Guid? xMsClientRequestId, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IndexesClient.List");
            scope.Start();
            try
            {
                using var message = CreateListRequest(select, xMsClientRequestId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            ListIndexesResult value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = ListIndexesResult.DeserializeListIndexesResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all indexes available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the index definitions to retrieve. Specified as a comma-separated list of JSON property names, or &apos;*&apos; for all properties. The default is all properties. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ListIndexesResult> List(string select, Guid? xMsClientRequestId, CancellationToken cancellationToken = default)
        {
            using var scope = clientDiagnostics.CreateScope("IndexesClient.List");
            scope.Start();
            try
            {
                using var message = CreateListRequest(select, xMsClientRequestId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            ListIndexesResult value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = ListIndexesResult.DeserializeListIndexesResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateCreateOrUpdateRequest(string indexName, bool? allowIndexDowntime, Guid? xMsClientRequestId, string ifMatch, string ifNoneMatch, SearchIndex index)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/indexes('", false);
            uri.AppendPath(indexName, true);
            uri.AppendPath("')", false);
            if (allowIndexDowntime != null)
            {
                uri.AppendQuery("allowIndexDowntime", allowIndexDowntime.Value, true);
            }
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (xMsClientRequestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", xMsClientRequestId.Value);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            request.Headers.Add("Prefer", "return=representation");
            request.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(index);
            request.Content = content;
            return message;
        }

        /// <summary> Creates a new search index or updates an index if it already exists. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="allowIndexDowntime"> Allows new analyzers, tokenizers, token filters, or char filters to be added to an index by taking the index offline for at least a few seconds. This temporarily causes indexing and query requests to fail. Performance and write availability of the index can be impaired for several minutes after the index is updated, or longer for very large indexes. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="index"> The definition of the index to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SearchIndex>> CreateOrUpdateAsync(string indexName, bool? allowIndexDowntime, Guid? xMsClientRequestId, string ifMatch, string ifNoneMatch, SearchIndex index, CancellationToken cancellationToken = default)
        {
            if (indexName == null)
            {
                throw new ArgumentNullException(nameof(indexName));
            }
            if (index == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.CreateOrUpdate");
            scope.Start();
            try
            {
                using var message = CreateCreateOrUpdateRequest(indexName, allowIndexDowntime, xMsClientRequestId, ifMatch, ifNoneMatch, index);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            SearchIndex value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = SearchIndex.DeserializeSearchIndex(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new search index or updates an index if it already exists. </summary>
        /// <param name="indexName"> The definition of the index to create or update. </param>
        /// <param name="allowIndexDowntime"> Allows new analyzers, tokenizers, token filters, or char filters to be added to an index by taking the index offline for at least a few seconds. This temporarily causes indexing and query requests to fail. Performance and write availability of the index can be impaired for several minutes after the index is updated, or longer for very large indexes. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="index"> The definition of the index to create or update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SearchIndex> CreateOrUpdate(string indexName, bool? allowIndexDowntime, Guid? xMsClientRequestId, string ifMatch, string ifNoneMatch, SearchIndex index, CancellationToken cancellationToken = default)
        {
            if (indexName == null)
            {
                throw new ArgumentNullException(nameof(indexName));
            }
            if (index == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.CreateOrUpdate");
            scope.Start();
            try
            {
                using var message = CreateCreateOrUpdateRequest(indexName, allowIndexDowntime, xMsClientRequestId, ifMatch, ifNoneMatch, index);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            SearchIndex value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = SearchIndex.DeserializeSearchIndex(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateDeleteRequest(string indexName, Guid? xMsClientRequestId, string ifMatch, string ifNoneMatch)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/indexes('", false);
            uri.AppendPath(indexName, true);
            uri.AppendPath("')", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (xMsClientRequestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", xMsClientRequestId.Value);
            }
            if (ifMatch != null)
            {
                request.Headers.Add("If-Match", ifMatch);
            }
            if (ifNoneMatch != null)
            {
                request.Headers.Add("If-None-Match", ifNoneMatch);
            }
            return message;
        }

        /// <summary> Deletes a search index and all the documents it contains. </summary>
        /// <param name="indexName"> The name of the index to delete. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response> DeleteAsync(string indexName, Guid? xMsClientRequestId, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            if (indexName == null)
            {
                throw new ArgumentNullException(nameof(indexName));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.Delete");
            scope.Start();
            try
            {
                using var message = CreateDeleteRequest(indexName, xMsClientRequestId, ifMatch, ifNoneMatch);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a search index and all the documents it contains. </summary>
        /// <param name="indexName"> The name of the index to delete. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="ifMatch"> Defines the If-Match condition. The operation will be performed only if the ETag on the server matches this value. </param>
        /// <param name="ifNoneMatch"> Defines the If-None-Match condition. The operation will be performed only if the ETag on the server does not match this value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response Delete(string indexName, Guid? xMsClientRequestId, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            if (indexName == null)
            {
                throw new ArgumentNullException(nameof(indexName));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.Delete");
            scope.Start();
            try
            {
                using var message = CreateDeleteRequest(indexName, xMsClientRequestId, ifMatch, ifNoneMatch);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 204:
                        return message.Response;
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetRequest(string indexName, Guid? xMsClientRequestId)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/indexes('", false);
            uri.AppendPath(indexName, true);
            uri.AppendPath("')", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (xMsClientRequestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", xMsClientRequestId.Value);
            }
            return message;
        }

        /// <summary> Retrieves an index definition. </summary>
        /// <param name="indexName"> The name of the index to retrieve. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<SearchIndex>> GetAsync(string indexName, Guid? xMsClientRequestId, CancellationToken cancellationToken = default)
        {
            if (indexName == null)
            {
                throw new ArgumentNullException(nameof(indexName));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.Get");
            scope.Start();
            try
            {
                using var message = CreateGetRequest(indexName, xMsClientRequestId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            SearchIndex value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = SearchIndex.DeserializeSearchIndex(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves an index definition. </summary>
        /// <param name="indexName"> The name of the index to retrieve. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<SearchIndex> Get(string indexName, Guid? xMsClientRequestId, CancellationToken cancellationToken = default)
        {
            if (indexName == null)
            {
                throw new ArgumentNullException(nameof(indexName));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.Get");
            scope.Start();
            try
            {
                using var message = CreateGetRequest(indexName, xMsClientRequestId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            SearchIndex value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = SearchIndex.DeserializeSearchIndex(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetStatisticsRequest(string indexName, Guid? xMsClientRequestId)
        {
            var message = pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/indexes('", false);
            uri.AppendPath(indexName, true);
            uri.AppendPath("')/search.stats", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            if (xMsClientRequestId != null)
            {
                request.Headers.Add("x-ms-client-request-id", xMsClientRequestId.Value);
            }
            return message;
        }

        /// <summary> Returns statistics for the given index, including a document count and storage usage. </summary>
        /// <param name="indexName"> The name of the index for which to retrieve statistics. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<GetIndexStatisticsResult>> GetStatisticsAsync(string indexName, Guid? xMsClientRequestId, CancellationToken cancellationToken = default)
        {
            if (indexName == null)
            {
                throw new ArgumentNullException(nameof(indexName));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.GetStatistics");
            scope.Start();
            try
            {
                using var message = CreateGetStatisticsRequest(indexName, xMsClientRequestId);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            GetIndexStatisticsResult value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = GetIndexStatisticsResult.DeserializeGetIndexStatisticsResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns statistics for the given index, including a document count and storage usage. </summary>
        /// <param name="indexName"> The name of the index for which to retrieve statistics. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<GetIndexStatisticsResult> GetStatistics(string indexName, Guid? xMsClientRequestId, CancellationToken cancellationToken = default)
        {
            if (indexName == null)
            {
                throw new ArgumentNullException(nameof(indexName));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.GetStatistics");
            scope.Start();
            try
            {
                using var message = CreateGetStatisticsRequest(indexName, xMsClientRequestId);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            GetIndexStatisticsResult value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = GetIndexStatisticsResult.DeserializeGetIndexStatisticsResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateAnalyzeRequest(string indexName, Guid? xMsClientRequestId, AnalyzeRequest request)
        {
            var message = pipeline.CreateMessage();
            var request0 = message.Request;
            request0.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(endpoint, false);
            uri.AppendPath("/indexes('", false);
            uri.AppendPath(indexName, true);
            uri.AppendPath("')/search.analyze", false);
            uri.AppendQuery("api-version", apiVersion, true);
            request0.Uri = uri;
            if (xMsClientRequestId != null)
            {
                request0.Headers.Add("x-ms-client-request-id", xMsClientRequestId.Value);
            }
            request0.Headers.Add("Content-Type", "application/json");
            using var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(request);
            request0.Content = content;
            return message;
        }

        /// <summary> Shows how an analyzer breaks text into tokens. </summary>
        /// <param name="indexName"> The name of the index for which to test an analyzer. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="request"> The text and analyzer or analysis components to test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async ValueTask<Response<AnalyzeResult>> AnalyzeAsync(string indexName, Guid? xMsClientRequestId, AnalyzeRequest request, CancellationToken cancellationToken = default)
        {
            if (indexName == null)
            {
                throw new ArgumentNullException(nameof(indexName));
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.Analyze");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeRequest(indexName, xMsClientRequestId, request);
                await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            AnalyzeResult value = default;
                            using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                            value = AnalyzeResult.DeserializeAnalyzeResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Shows how an analyzer breaks text into tokens. </summary>
        /// <param name="indexName"> The name of the index for which to test an analyzer. </param>
        /// <param name="xMsClientRequestId"> The tracking ID sent with the request to help with debugging. </param>
        /// <param name="request"> The text and analyzer or analysis components to test. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<AnalyzeResult> Analyze(string indexName, Guid? xMsClientRequestId, AnalyzeRequest request, CancellationToken cancellationToken = default)
        {
            if (indexName == null)
            {
                throw new ArgumentNullException(nameof(indexName));
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            using var scope = clientDiagnostics.CreateScope("IndexesClient.Analyze");
            scope.Start();
            try
            {
                using var message = CreateAnalyzeRequest(indexName, xMsClientRequestId, request);
                pipeline.Send(message, cancellationToken);
                switch (message.Response.Status)
                {
                    case 200:
                        {
                            AnalyzeResult value = default;
                            using var document = JsonDocument.Parse(message.Response.ContentStream);
                            value = AnalyzeResult.DeserializeAnalyzeResult(document.RootElement);
                            return Response.FromValue(value, message.Response);
                        }
                    default:
                        throw clientDiagnostics.CreateRequestFailedException(message.Response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
