# Release Notes

## 4.1.0 - ?

Breaking changes:
- (None)

New features:
- Added `HttpContentExtensions.IsMediaType` method.

Bug fixes / internal changes:
- (None)

## 4.0.0 - 30 November 2021

Breaking changes:
- Renamed `HttpStatusCode` to `HttpStatusCodeInfo` (to avoid `System.Net.HttpStatusCode` confusion).
- Added private constructor to `HttpStatusCodeInfo`.

New features:
- Added `HttpStatusCodeInfo.CreateFromCode` overload that takes `System.Net.HttpStatusCode` argument.
- Added `HttpStatusCodeCategory.CreateFromHttpStatusCode` overload that takes `System.Net.HttpStatusCode` argument.

Bug fixes / internal changes:
- (None)

## 3.0.0 - 20 October 2021

Breaking changes:
- Removed `HttpContentExtensions.ReadAsJsonAsync` method.
- Removed `HttpContentExtensions.ReadAsXmlAsync` method.

New features:
- Added `HttpRequestHeadersExtensions.AddUserAgent` method.
- Added `HttpRequestHeadersExtensions.AddOrUpdate` method.
- Added `HttpContentExtensions.IsJson` method.
- Added `HttpContentExtensions.IsXml` method.
- Added `HttpContentExtensions.IsFormUrlEncoded` method.
- Added more `MediaTypes` fields.

Bug fixes / internal changes:
- Removed `System.Text.Json` package dependency.

## 2.2.0 - 11 August 2021

Breaking changes:
- (None)

New features:
- Added `EmptyContent` class.

Bug fixes / internal changes:
- (None)

## 2.1.0 - 06 July 2021

Breaking changes:
- (None)

New features:
- Added more properties to `HttpStatusCodeCategory`.

Bug fixes / internal changes:
- Removed `ByteDev.Reflection` package dependency (no longer needed).

## 2.0.0 - 17 June 2021

Breaking changes:
- Removed entire `FormUrlEncoded` namespace and form URL encoded serialzation functionality (moved to package: `ByteDev.FormUrlEncoded`).
- Removed `HttpContentExtensions.ReadAsFormUrlEncodedAsync` method.
- Moved `FormUrlEncodedContent` to namespace `ByteDev.Http.Content`.
- Moved `JsonContent` to namespace `ByteDev.Http.Content`.
- Moved `XmlContent` to namespace `ByteDev.Http.Content`.

New features:
- (None)

Bug fixes / internal changes:
- Updated `ByteDev.Reflection` package dependency to 2.3.1.

## 1.5.0 - 04 November 2020

Breaking changes:
- (None)

New features:
- Added `HttpContentExtensions.ReadAsJsonAsync` method.
- Added `HttpContentExtensions.ReadAsXmlAsync` method.
- Added `HttpContentExtensions.ReadAsFormUrlEncodedAsync` method.
- Added `HttpContentHeadersExtensions.AddOrUpdate` method.
- Added `JsonContent` class.
- Added `XmlContent` class.
- Added `FormUrlEncodedContent` class.

Bug fixes / internal changes:
- `FormUrlEncodedSerializer.Deserialize` if options is null then defaults are now used (no exception thrown)

## 1.4.1 - 28 September 2020

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- Package now has dependency on `ByteDev.Reflection`.
- Package fixes.

## 1.4.0 - 05 June 2020

Breaking changes:
- (None)

New features:
- Added `FormUrlEncodedPropertyNameAttribute` class.

Bug fixes:
- (None)

## 1.3.0 - 03 June 2020

Breaking changes:
- (None)

New features:
- Added overloads for `FormUrlEncodedSerializer.Serialize` and `Deserialize` methods.

Bug fixes:
- Modified nuspec
- Added complete XML documentation to public properties and methods.

## 1.2.0 - 02 June 2020

Breaking changes:
- (None)

New features:
- Added `FormUrlEncodedSerializer` class.

Bug fixes:
- (None)

## 1.1.0 - 28 May 2020

Breaking changes:
- (None)

New features:
- Added `MediaType`.
- Added `MediaTypes`.

Bug fixes / internal changes:
- (None)

## 1.0.0 - 10 May 2020

Initial version.
