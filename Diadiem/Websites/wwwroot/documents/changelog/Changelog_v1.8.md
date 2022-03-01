# Địa Điểm API v1.8


### Cập nhật


## ``FRONTEND USER *[28/05/2020]*``
* FRONTEND USER *[28/05/2020]*

• Device:

        **Users**: Thông tin người dùng khi đăng nhập thiết bị.

    1.Thêm mới Users Thông tin thiết lập theo tài khoản được tạo ra.

        ◦ **CustomerCode**: Mã đăng nhập thiết bị.
        ◦ **BusinessName**: Tên store kinh doanh.
        ◦ **Language**: Ngôn ngữ hiển thị - cho phép giao diện hiển thị theo nhiều ngôn ngữ khác nhau. isMain=true: Ngôn ngữ hiển thị chính hoặc mặc định.
        ◦ **TimeZoneDisplayName**: Tên store kinh doanh.
        ◦ **CurrencyId**: Mã currency.
        ◦ **CurrencyNativeName**: Tên hiển thị đầy đủ currency. Chỉ sử dụng cho một số vị trí cần thiết trong setting hệ thống.
        ◦ **CurrencySymbol**: Ký tự đặc trưng cho currency. Sử dụng và hiển thị ra trên giá hoặc những vị trí để biết hệ thống có nhiều currency hoặc currency tương ứng.

Example: /api/Device?AppCode=PVJ5-HXPV-CWEA


```{
  "Message": null,
  "DidError": false,
  "ErrorMessage": null,
  "Model": [
    {
      "Device": [
        {
          "_Id": "Device/438231094",
          "_rev": "_ajj8bfC--_",
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
          "InDate": "2020-05-28T04:15:59",
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
          "TimeZoneInfoDetail": "Thursday, 28 May 2020 11:18 AM",
          "TimeZoneInfoDate": "Thursday, 28 May 2020",
          "TimeZoneInfoTime": "11:18 AM",
          "TimeZoneInfoMyDayFormat": "Thứ Năm, 28 Tháng Năm",
          "TimeZoneInfoMyTimeFormat": "11:18",
          "TimeZoneInfoNow": "2020-05-28T11:18:39"
        }
      ],
      "DeviceInfoGuid": "DeviceInfo/3494",
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
      "ViewItemMode": [
        {
          "ViewMode": [
            {
              "Id": 3,
              "Title_vi": "Màu",
              "Title_en": "Color",
              "Handle": "color",
              "OrderNo": 2,
              "Visible": 1,
              "Default": 0
            }
          ],
          "PictureMode": [
            {
              "Id": 2,
              "Title_vi": "Hình",
              "Title_en": "Picture",
              "Handle": "picture",
              "OrderNo": 1,
              "Visible": 1,
              "Default": 0
            }
          ]
        }
      ],
      [x]"Users": {
        "CustomerCode": "0IRVDG",
        "BusinessName": "Pendogo",
        "Language": "[{\"_Id\":\"CustomerLanguages/1\",\"_rev\":\"_ajj6Uta---\",\"_key\":1,\"Flag\":\"images/img_flag/United_States.png\",\"Country\":null,\"Code\":\"en\",\"Language\":\"English (United States)\",\"IsMain\":true,\"OrderNo\":0,\"Visible\":1},{\"_Id\":\"CustomerLanguages/2\",\"_rev\":\"_ajj6Uu----\",\"_key\":2,\"Flag\":\"images/img_flag/Germany.png\",\"Country\":null,\"Code\":\"de\",\"Language\":\"German (Germany)\",\"IsMain\":false,\"OrderNo\":1,\"Visible\":1},{\"_Id\":\"CustomerLanguages/3\",\"_rev\":\"_ajj6Uum---\",\"_key\":3,\"Flag\":\"images/img_flag/Viet_Nam.png\",\"Country\":null,\"Code\":\"vi\",\"Language\":\"Vietnamese (Vietnam)\",\"IsMain\":false,\"OrderNo\":2,\"Visible\":1}]",
        "CurrencyId": "[\"Đồng (₫)\"]",
        "TimeZoneDisplayName": "(UTC+07:00) Bangkok, Hanoi, Jakarta",
        "CurrencyNativeName": "Đồng",
        "CurrencySymbol": "₫"
      }[x]
    }
  ],
  "PageSize": 0,
  "PageNumber": 0,
  "ItemsCount": 0,
  "PageCount": -2147483648.0
}
```


