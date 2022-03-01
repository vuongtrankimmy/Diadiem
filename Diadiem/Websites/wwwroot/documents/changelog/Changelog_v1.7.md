# Địa Điểm API v1.7


### Cập nhật


## ``FRONTEND USER *[23/05/2020]*``
* **Device: ViewItemMode hiển thị theo thiết bị**   
1. Thêm mới **ViewItemMode** trong dữ liệu để khi đăng nhập thiết bị hiển thị Item phù hợp với settings.

    * **ViewMode**: Hiển thị Item sử dụng cho Page 1.
    
        * *Loại hiển thị*: 1: **Text**, 2: **Picture**, 3: **Color**, 4: **Mixed**
        
    * **PictureMode**: Hiển thị Item sử dụng cho Page 2......n.
    
        * *Loại hiển thị*:    1: **Text**, 2: **Picture**, 3: **Mixed**

Example: **/api/Device?AppCode=PVJ5-HXPV-CWEA**

```json
{
  "Message": null,
  "DidError": false,
  "ErrorMessage": null,
  "Model": [
    {
      "Device": [
        {
          "_Id": "Device/438231094",
          "_rev": "_ai-dX8y--_",
          "_key": 438231094,
          "Nickname": "Cashier",
          "Location": "Location/425242095",
          "DeviceType": 1,
          "RequestNotification": null,
          "EnableNotification": null,
          "EnableLocation": null,
          "AppCode": "PVJ5-HXPV-CWEA",
          "HexCode": "8fa7497a380d4f7387966c6e1e2402d3_20200210155917",
          "CreateDate": "2020-02-10T15:59:17",
          "InDate": "2020-05-23T13:01:14",
          "OutDate": "0001-01-01T00:00:00",
          "Status": 2,
          "UserGuid": "Customer/438227755",
          "Visible": 1,
          "DeviceId": 14
        }
      ],
      "Region": [
        {
          "DisplayName": "Vietnamese (Vietnam)",
          "EnglishName": "Vietnamese (Vietnam)",
          "FullDateTimePattern": "dd MMMM yyyy h:mm:ss tt",
          "LongDatePattern": "dd MMMM yyyy",
          "LongTimePattern": "h:mm:ss tt",
          "ShortDatePattern": "dd/MM/yyyy",
          "ShortTimePattern": "h:mm tt",
          "DayNames": [
            "Chủ Nhật",
            "Thứ Hai",
            "Thứ Ba",
            "Thứ Tư",
            "Thứ Năm",
            "Thứ Sáu",
            "Thứ Bảy"
          ],
          "MonthNames": [
            "Tháng Giêng",
            "Tháng Hai",
            "Tháng Ba",
            "Tháng Tư",
            "Tháng Năm",
            "Tháng Sáu",
            "Tháng Bảy",
            "Tháng Tám",
            "Tháng Chín",
            "Tháng Mười",
            "Tháng Mười Một",
            "Tháng Mười Hai",
            ""
          ],
          "CurrencySymbol": "₫",
          "CurrencyDecimalDigits": 2,
          "CurrencyDecimalSeparator": ",",
          "CurrencyGroupSeparator": ".",
          "NumberDecimalDigits": 2,
          "NumberNegativePattern": "1",
          "PerMilleSymbol": "‰",
          "PercentDecimalDigits": 2,
          "PercentDecimalSeparator": ",",
          "TextInfo": "vi-VN",
          "ThreeLetterISOLanguageName": "vie",
          "ThreeLetterWindowsLanguageName": "VIT",
          "TwoLetterISOLanguageName": "vi",
          "RegionTwoLetterISORegionName": "VN",
          "RegionThreeLetterWindowsRegionName": "VNM",
          "RegionGeoId": 251,
          "RegionName": "VN",
          "RegionDisplayName": "Vietnam",
          "RegionNativeName": "Việt Nam",
          "NumericCode": 704,
          "DialCodes": [
            "84"
          ]
        }
      ],
      "SystemTimeZoneInfo": [
        {
          "SystemTimeZone": "(UTC+07:00) Bangkok, Hanoi, Jakarta",
          "Id": "SE Asia Standard Time",
          "DaylightName": "SE Asia Daylight Time",
          "DisplayName": "(UTC+07:00) Bangkok, Hanoi, Jakarta",
          "BaseUtcOffset": "07:00:00",
          "StandardName": "SE Asia Standard Time",
          "SupportsDaylightSavingTime": false,
          "TimeZoneInfoDetail": "Saturday, 23 May 2020 1:11 PM",
          "TimeZoneInfoDate": "Saturday, 23 May 2020",
          "TimeZoneInfoTime": "1:11 PM",
          "TimeZoneInfoMyDayFormat": "Thứ Bảy, 23 Tháng Năm",
          "TimeZoneInfoMyTimeFormat": "13:11",
          "TimeZoneInfoNow": "2020-05-23T13:11:59"
        }
      ],
      "DeviceInfoGuid": "DeviceInfo/3004",
      "Employees": [
        {
          "_Id": "Employee/2578770",
          "_rev": "_aA4K3le--_",
          "_key": 2578770,
          "FirstName": "Hien",
          "LastName": "Cao",
          "FullName": "Hien Cao",
          "NameAcronymn": "H",
          "Avatar": "",
          "DateOfBirth": "0001-01-01T00:00:00",
          "PassCode": "1234",
          "Email": "hiencao@gmail.com",
          "Phone": "",
          "Department": 0,
          "Position": 0,
          "Country": 0,
          "City": 0,
          "Ward": 0
        },
        {
          "_Id": "Employee/2578941",
          "_rev": "_aA4Pnda--_",
          "_key": 2578941,
          "FirstName": "Vương",
          "LastName": "Trần",
          "FullName": "Vương Trần",
          "NameAcronymn": "V",
          "Avatar": "",
          "DateOfBirth": "0001-01-01T00:00:00",
          "PassCode": "1235",
          "Email": "",
          "Phone": "",
          "Department": 0,
          "Position": 0,
          "Country": 0,
          "City": 0,
          "Ward": 0
        },
        {
          "_Id": "Employee/3116129",
          "_rev": "_aEqqdgS--_",
          "_key": 3116129,
          "FirstName": "Quân",
          "LastName": "Nguyễn",
          "FullName": "Quân Nguyễn",
          "NameAcronymn": "Q",
          "Avatar": "",
          "DateOfBirth": "0001-01-01T00:00:00",
          "PassCode": "5678",
          "Email": "quannguyen12@gmail.com",
          "Phone": "093365789",
          "Department": 0,
          "Position": 0,
          "Country": 0,
          "City": 0,
          "Ward": 0
        }
      ],
      > **"ViewItemMode": [
        {
          "ViewMode": [
            {
              "Id": 1,
              "Title_vi": "Chữ",
              "Title_en": "Text",
              "Handle": "text",
              "OrderNo": 0,
              "Visible": 1,
              "Default": 1
            }
          ],
          "PictureMode": [
            {
              "Id": 1,
              "Title_vi": "Hình",
              "Title_en": "Picture",
              "Handle": "picture",
              "OrderNo": 0,
              "Visible": 1,
              "Default": 1
            }
          ]
        }
      ]**> 
    }
  ],
  "PageSize": 0,
  "PageNumber": 0,
  "ItemsCount": 0,
  "PageCount": -2147483648.0
}
```


