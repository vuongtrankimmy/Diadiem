# Địa Điểm API v1.2


### Cập nhật

## ``FRONTEND USER *[10/02/2020]*``

* **Update: Device**  
    1. Đăng nhập Thiết bị bằng `DeviceCode`.
    2. Cập nhật **`POST`** Method để lưu thông tin thiết bị xuống hệ thống theo `DeviceInfoGuid`.

## ``POS UI *[10/02/2020]*``

* **Update: TimeZone**  
    1. Cập nhập lỗi định dạng TimeZone.
    2. Cập nhật lại ngôn ngữ hiển thị theo TimeZone (Ưu tiên tiếng anh).



```json

[
  {
    "Device": [
      {
        "_Id": "Device/76",
        "_rev": "_a_lOhD6--_",
        "_key": 76,
        "Nickname": "Cashier",
        "Location": "Location/17",
        "DeviceType": 1,
        "RequestNotification": 1,
        "EnableNotification": 1,
        "EnableLocation": 1,
        "AppCode": "5X5C-CB3U-6CUY",
        "HexCode": "8137a2174e1944c682589265fd1f911c_20190927100844",
        "CreateDate": "2019-09-27T10:08:43",
        "InDate": "0001-01-01T00:00:00",
        "OutDate": "0001-01-01T00:00:00",
        "Status": 1,
        "UserGuid": "Customer/20",
        "Visible": 1,
        "DeviceId": 31
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
        "TimeZoneInfoDetail": "Friday, 14 February 2020 9:56 AM",
        "TimeZoneInfoDate": "Friday, 14 February 2020",
        "TimeZoneInfoTime": "9:56 AM",
        [x]"TimeZoneInfoMyDayFormat": "Thứ Sáu, 14 Tháng Hai",
        "TimeZoneInfoMyTimeFormat": "09:56",
        [x]"TimeZoneInfoNow": "2020-02-14T09:56:45"
      }
    ],
    [x] "DeviceInfoGuid": "DeviceInfo/6"
  }
]
```
