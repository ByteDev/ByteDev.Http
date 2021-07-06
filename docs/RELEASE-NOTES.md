# Release Notes

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
- Added `HttpContentExtensions.ReadAsJsonAsync`
- Added `HttpContentExtensions.ReadAsXmlAsync`
- Added `HttpContentExtensions.ReadAsFormUrlEncodedAsync`
- Added `HttpContentHeadersExtensions.AddOrUpdate`
- Added `JsonContent`
- Added `XmlContent`
- Added `FormUrlEncodedContent`

Bug fixes / internal changes:
- `FormUrlEncodedSerializer.Deserialize` if options is null then defaults are now used (no exception thrown)

## 1.4.1 - 28 September 2020

Breaking changes:
- (None)

New features:
- (None)

Bug fixes / internal changes:
- Package now has dependency on `ByteDev.Reflection`
- Package fixes

## 1.4.0 - 05 June 2020

Breaking changes:
- (None)

New features:
- Added `FormUrlEncodedPropertyNameAttribute`

Bug fixes:
- (None)

## 1.3.0 - 03 June 2020

Breaking changes:
- (None)

New features:
- Added overloads for `FormUrlEncodedSerializer.Serialize` and `Deserialize`

Bug fixes:
- Modified nuspec
- Added complete XML documentation to public properties and methods

## 1.2.0 - 02 June 2020

Breaking changes:
- (None)

New features:
- Added `FormUrlEncodedSerializer`

Bug fixes:
- (None)

## 1.1.0 - 28 May 2020

Breaking changes:
- (None)

New features:
- Added `MediaType`
- Added `MediaTypes`

Bug fixes / internal changes:
- (None)

## 1.0.0 - 10 May 2020

Initial version.
