# Địa Điểm API v1.3


### Cập nhật

## ``POS UI *[21/02/2020]*``

* **Update: TimeZone**  
    1. Cập nhập api/pos/ui **font-size**  `Welcome`,`Device Code`,`Pass_Code`.
    2. Thêm mới Field **Circle** Trong `Pass_Code`.

>***Note***:  
>  - [x]: Vị trí thay đổi trên dữ liệu
--------------------------------------
<br>

```json

{
  "Message": null,
  "DidError": false,
  "ErrorMessage": null,
  "Model": [
    {
      "Settings_Css": [
        {
          "Font_Family": "Roboto",
          "Font_Size": "20"
        }
      ],
      "Welcome": [
        {
          "Pages_Welcome": [
            {
              "PagesId": 1,
              "Logo": "http://pos_images.diadiem.com/pos/logo/logo.png",
              "Background": "http://pos_images.diadiem.com/pos/welcome/ipad/2388/Background.jpg?v=1.0",
              "Css": [
                {
                  "Title": [
                    {
                      "Color": "#efefef",
                      [x]"Font_Size": 100,
                      "Font_Weight": "Bold",
                      "Background": null
                    }
                  ],
                  "Description": [
                    {
                      "Color": "#efefef",
                      [x]"Font_Size": 60,
                      "Font_Weight": "Regular",
                      "Background": null
                    }
                  ],
                  "Button": [
                    {
                      "Color": "#efefef",
                      [x]"Font_Size": 400,
                      "Font_Weight": "Regular",
                      "Background": null
                    }
                  ]
                }
              ],
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
              "Css": [
                {
                  "Title": [
                    {
                      "Color": "#333333",
                      [x]"Font_Size": 40,
                      "Font_Weight": "Bold",
                      "Background": null
                    }
                  ],
                  "Description": [
                    {
                      "Color": "#999999",
                      [x]"Font_Size": 30,
                      "Font_Weight": "Regular",
                      "Background": null
                    }
                  ],
                  "Box_Text": [
                    {
                      "Color": "#bfbfbf",
                      [x]"Font_Size": 35,
                      "Font_Weight": "Regular",
                      "Background": null
                    }
                  ],
                  "Button": [
                    {
                      "Color": "#ffffff",
                      [x]"Font_Size": 40,
                      "Font_Weight": "Regular",
                      "Background": null
                    }
                  ]
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
              "Css": [
                {
                  "DateTime": [
                    {
                      "Color": "#ffffff",
                      [x]"Font_Size": 60,
                      "Font_Weight": "Bold"
                    }
                  ],
                  "NumPad": [
                    {
                      "Color": "#ffffff",
                      [x]"Font_Size": 60,
                      "Font_Weight": "Bold"
                    }
                  ],
                  "Button": [
                    {
                      "Color": "#ffffff",
                      [x]"Font_Size": 40,
                      "Font_Weight": "Regular"
                    }
                  ],
                  "ClockInOut": [
                    {
                      "Color": "#ffffff",
                      [x]"Font_Size": 40,
                      "Font_Weight": "Regular"
                    }
                  ],
                  "Title": [
                    {
                      "Color": "#ffffff",
                      [x]"Font_Size": 30,
                      "Font_Weight": "Regular"
                    }
                  ],
                  [x] "Circle": [
                    {
                     "Background": "http://pos_images.diadiem.com/pos/pass-code/Circle.png",
                     "BackgroundFill": "http://pos_images.diadiem.com/pos/pass-code/Circle_fill.png"
                    }
                  ][x]
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
