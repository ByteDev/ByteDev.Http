# Release Notes

## 1.5.0 - ?? October 2020

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
