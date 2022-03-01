# Địa Điểm API v1.4


### Cập nhật

## ``POS UI *[20/03/2020]*``

* **Update: Setting Css**  
    1. Cập nhập api/pos/ui **font-size**  `Setting_Css`.
    2. Thêm mới Field **Employee** Trong `Device`.

>***Note***:  
>  - [ x ]: Vị trí thay đổi trên dữ liệu
--------------------------------------
1. `Setting_Css`
<br>

```json

{
  "Message": null,
  "DidError": false,
  "ErrorMessage": null,
  "Model": [
    {
      [x][x][x]"Settings_Css": [
        {
          "Font_Family": "Roboto",
          "A": [
            {
              "Resolution": "9.7, 10.2, 10.5 , 11.0",
              "H1": 120,
              "H2": 60,
              "H3": 40,
              "H4": 35,
              "H5": 30,
              "H6": 25,
              "H7": 0,
              "P": 20
            }
          ],
          "B": [
            {
              "Resolution": "7.9",
              "H1": 100,
              "H2": 50,
              "H3": 34,
              "H4": 30,
              "H5": 25,
              "H6": 21,
              "H7": 0,
              "P": 17
            }
          ],
          "C": [
            {
              "Resolution": "12.9",
              "H1": 144,
              "H2": 72,
              "H3": 48,
              "H4": 42,
              "H5": 36,
              "H6": 30,
              "H7": 0,
              "P": 24
            }
          ]
        }
      ],[x][x][x]
      "Welcome": [
        {
          "Pages_Welcome": [
            {
              "PagesId": 1,
              "Logo": "http://pos_images.diadiem.com/pos/logo/logo.png",
              "Background": "http://pos_images.diadiem.com/pos/welcome/ipad/2388/Background.jpg?v=1.0",
              "Visible": 0
            }
          ],
          "Pages_Welcome_Text": [
            {
              "PagesId": 1,
              "Title": "Diadiem Point of Sale",
              "Description": "Run and grow your business",
              "Button": "Get Started"
            }
          ]
        }
      ],
      "Device_Code": [
        {
          "Pages_Device_Code": [
            {
              "PagesId": 1,
              "Background": [
                {
                  "Color1": "#ffffff"
                }
              ],
              "Visible": 0
            }
          ],
          "Pages_Device_Code_Text": [
            {
              "PagesId": 1,
              "Title": "Sign In With Device Code",
              "Description": "Devices Codes are created in Dashboard for each new device, allowing you to sign in without ever sharing your email and password.",
              "Button": "Sign In"
            }
          ]
        }
      ],
      "Pass_Code": [
        {
          "Pages_Pass_Code": [
            {
              "PagesId": 1,
              "Background": [
                {
                  "Color1": "#546376",
                  "Color2": "#000000"
                }
              ],
              "Visible": 1
            }
          ],
          "Pages_Pass_Code_Text": [
            {
              "PagesId": 1,
              "Button": "Clock In/Out"
            }
          ]
        }
      ]
    }
  ],
  "PageSize": 0,
  "PageNumber": 0,
  "ItemsCount": 0,
  "PageCount": -2147483648.0
}
```

<br><br>

2. `Setting_Css`
<br>

```json

{
  "Message": null,
  "DidError": false,
  "ErrorMessage": null,
  "Model": [
    {
      "Device": [
        {
          "_Id": "Device/438231102",
          "_rev": "_aDGa-G6--_",
          "_key": 438231102,
          "Nickname": "Cashier",
          "Location": "Location/425242107",
          "DeviceType": 1,
          "RequestNotification": null,
          "EnableNotification": null,
          "EnableLocation": null,
          "AppCode": "KWE2-G6HX-NXF9",
          "HexCode": "666eda6b39004ef7bbda01bedabe43f2_20200211160001",
          "CreateDate": "2020-02-11T16:00:01",
          "InDate": "2020-02-17T07:45:31",
          "OutDate": "0001-01-01T00:00:00",
          "Status": 2,
          "UserGuid": "Customer/438227760",
          "Visible": 1,
          "DeviceId": 21
        }
      ],
      "Region": [
        {
          "DisplayName": "Cherokee (Cherokee)",
          "EnglishName": "Cherokee (Cherokee, United States)",
          "FullDateTimePattern": "dddd, MMMM dd,yyyy h:mm:ss tt",
          "LongDatePattern": "dddd, MMMM dd,yyyy",
          "LongTimePattern": "h:mm:ss tt",
          "ShortDatePattern": "M/d/yyyy",
          "ShortTimePattern": "h:mm tt",
          "DayNames": [
            "ᎤᎾᏙᏓᏆᏍᎬ",
            "ᎤᎾᏙᏓᏉᏅᎯ",
            "ᏔᎵᏁᎢᎦ",
            "ᏦᎢᏁᎢᎦ",
            "ᏅᎩᏁᎢᎦ",
            "ᏧᎾᎩᎶᏍᏗ",
            "ᎤᎾᏙᏓᏈᏕᎾ"
          ],
          "MonthNames": [
            "ᎤᏃᎸᏔᏅ",
            "ᎧᎦᎵ",
            "ᎠᏅᏱ",
            "ᏝᏬᏂ",
            "ᎠᏂᏍᎬᏘ",
            "ᏕᎭᎷᏱ",
            "ᎫᏰᏉᏂ",
            "ᎦᎶᏂ",
            "ᏚᎵᏍᏗ",
            "ᏚᏂᏅᏗ",
            "ᏅᏓᏕᏆ",
            "ᎤᏍᎩᏱ",
            ""
          ],
          "CurrencySymbol": "$",
          "CurrencyDecimalDigits": 2,
          "CurrencyDecimalSeparator": ".",
          "CurrencyGroupSeparator": ",",
          "NumberDecimalDigits": 2,
          "NumberNegativePattern": "1",
          "PerMilleSymbol": "‰",
          "PercentDecimalDigits": 2,
          "PercentDecimalSeparator": ".",
          "TextInfo": "chr-Cher-US",
          "ThreeLetterISOLanguageName": "chr",
          "ThreeLetterWindowsLanguageName": "CRE",
          "TwoLetterISOLanguageName": "chr",
          "RegionTwoLetterISORegionName": "US",
          "RegionThreeLetterWindowsRegionName": "USA",
          "RegionGeoId": 244,
          "RegionName": "US",
          "RegionDisplayName": "United States",
          "RegionNativeName": "ᏌᏊ ᎢᏳᎾᎵᏍᏔᏅ ᏍᎦᏚᎩ",
          "NumericCode": 840,
          "DialCodes": [
            "1"
          ]
        },
        {
          "DisplayName": "English (United States)",
          "EnglishName": "English (United States)",
          "FullDateTimePattern": "dddd, MMMM d, yyyy h:mm:ss tt",
          "LongDatePattern": "dddd, MMMM d, yyyy",
          "LongTimePattern": "h:mm:ss tt",
          "ShortDatePattern": "M/d/yyyy",
          "ShortTimePattern": "h:mm tt",
          "DayNames": [
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"
          ],
          "MonthNames": [
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December",
            ""
          ],
          "CurrencySymbol": "$",
          "CurrencyDecimalDigits": 2,
          "CurrencyDecimalSeparator": ".",
          "CurrencyGroupSeparator": ",",
          "NumberDecimalDigits": 2,
          "NumberNegativePattern": "1",
          "PerMilleSymbol": "‰",
          "PercentDecimalDigits": 2,
          "PercentDecimalSeparator": ".",
          "TextInfo": "en-US",
          "ThreeLetterISOLanguageName": "eng",
          "ThreeLetterWindowsLanguageName": "ENU",
          "TwoLetterISOLanguageName": "en",
          "RegionTwoLetterISORegionName": "US",
          "RegionThreeLetterWindowsRegionName": "USA",
          "RegionGeoId": 244,
          "RegionName": "US",
          "RegionDisplayName": "United States",
          "RegionNativeName": "United States",
          "NumericCode": 840,
          "DialCodes": [
            "1"
          ]
        },
        {
          "DisplayName": "Hawaiian (United States)",
          "EnglishName": "Hawaiian (United States)",
          "FullDateTimePattern": "dddd, d MMMM yyyy h:mm:ss tt",
          "LongDatePattern": "dddd, d MMMM yyyy",
          "LongTimePattern": "h:mm:ss tt",
          "ShortDatePattern": "d/M/yyyy",
          "ShortTimePattern": "h:mm tt",
          "DayNames": [
            "Lāpule",
            "Poʻakahi",
            "Poʻalua",
            "Poʻakolu",
            "Poʻahā",
            "Poʻalima",
            "Poʻaono"
          ],
          "MonthNames": [
            "Ianuali",
            "Pepeluali",
            "Malaki",
            "ʻApelila",
            "Mei",
            "Iune",
            "Iulai",
            "ʻAukake",
            "Kepakemapa",
            "ʻOkakopa",
            "Nowemapa",
            "Kekemapa",
            ""
          ],
          "CurrencySymbol": "$",
          "CurrencyDecimalDigits": 2,
          "CurrencyDecimalSeparator": ".",
          "CurrencyGroupSeparator": ",",
          "NumberDecimalDigits": 2,
          "NumberNegativePattern": "1",
          "PerMilleSymbol": "‰",
          "PercentDecimalDigits": 2,
          "PercentDecimalSeparator": ".",
          "TextInfo": "haw-US",
          "ThreeLetterISOLanguageName": "haw",
          "ThreeLetterWindowsLanguageName": "HAW",
          "TwoLetterISOLanguageName": "haw",
          "RegionTwoLetterISORegionName": "US",
          "RegionThreeLetterWindowsRegionName": "USA",
          "RegionGeoId": 244,
          "RegionName": "US",
          "RegionDisplayName": "United States",
          "RegionNativeName": "ʻAmelika Hui Pū ʻIa",
          "NumericCode": 840,
          "DialCodes": [
            "1"
          ]
        },
        {
          "DisplayName": "Spanish (United States)",
          "EnglishName": "Spanish (United States)",
          "FullDateTimePattern": "dddd, MMMM dd, yyyy h:mm:ss tt",
          "LongDatePattern": "dddd, MMMM dd, yyyy",
          "LongTimePattern": "h:mm:ss tt",
          "ShortDatePattern": "M/d/yyyy",
          "ShortTimePattern": "h:mm tt",
          "DayNames": [
            "domingo",
            "lunes",
            "martes",
            "miércoles",
            "jueves",
            "viernes",
            "sábado"
          ],
          "MonthNames": [
            "enero",
            "febrero",
            "marzo",
            "abril",
            "mayo",
            "junio",
            "julio",
            "agosto",
            "septiembre",
            "octubre",
            "noviembre",
            "diciembre",
            ""
          ],
          "CurrencySymbol": "$",
          "CurrencyDecimalDigits": 2,
          "CurrencyDecimalSeparator": ".",
          "CurrencyGroupSeparator": ",",
          "NumberDecimalDigits": 2,
          "NumberNegativePattern": "1",
          "PerMilleSymbol": "‰",
          "PercentDecimalDigits": 2,
          "PercentDecimalSeparator": ".",
          "TextInfo": "es-US",
          "ThreeLetterISOLanguageName": "spa",
          "ThreeLetterWindowsLanguageName": "EST",
          "TwoLetterISOLanguageName": "es",
          "RegionTwoLetterISORegionName": "US",
          "RegionThreeLetterWindowsRegionName": "USA",
          "RegionGeoId": 244,
          "RegionName": "US",
          "RegionDisplayName": "United States",
          "RegionNativeName": "Estados Unidos",
          "NumericCode": 840,
          "DialCodes": [
            "1"
          ]
        }
      ],
      "SystemTimeZoneInfo": [
        {
          "SystemTimeZone": "(UTC-07:00) Mountain Time (US & Canada)",
          "Id": "Mountain Standard Time",
          "DaylightName": "Mountain Daylight Time",
          "DisplayName": "(UTC-07:00) Mountain Time (US & Canada)",
          "BaseUtcOffset": "-07:00:00",
          "StandardName": "Mountain Standard Time",
          "SupportsDaylightSavingTime": true,
          "TimeZoneInfoDetail": "Friday, March 20, 2020 3:56 AM",
          "TimeZoneInfoDate": "Friday, March 20, 2020",
          "TimeZoneInfoTime": "3:56 AM",
          "TimeZoneInfoMyDayFormat": "Thursday, March 19,",
          "TimeZoneInfoMyTimeFormat": "03:56",
          "TimeZoneInfoNow": "2020-03-20T03:56:59"
        }
      ],
      "DeviceInfoGuid": "DeviceInfo/275",
      [x][x][x]"Employees": [
        {
          "_Id": "Employee/2624283",
          "_rev": "_aBL6H2q--_",
          "_key": 2624283,
          "FirstName": "Hằng",
          "LastName": "Trần",
          "DateOfBirth": "0001-01-01T00:00:00",
          "PassCode": "xxxx",
          "Email": "",
          "Phone": "",
          "Department": 0,
          "Position": 0,
          "Country": 0,
          "City": 0,
          "Ward": 0
        }
      ][x][x][x]
    }
  ],
  "PageSize": 0,
  "PageNumber": 0,
  "ItemsCount": 0,
  "PageCount": -2147483648.0
}
```
