# Địa Điểm API v1.5


### Cập nhật

## ``POS UI *[21/04/2020]*``

* **Update: Frontend User**  
    1. Cập nhập **api/device** : ***FullName**, **NameAcronymn**, **Avatar***  `Employees`.
    2. Cập nhập **api/pos/floor**.

>***Note***:  
>  - [ x ]: Vị trí thay đổi trên dữ liệu
--------------------------------------
1. `api/device`
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
          "_Id": "Device/76",
          "_rev": "_aXpidW---_",
          "_key": 76,
          "Nickname": "Cashier",
          "Location": "Location/17",
          "DeviceType": 1,
          "RequestNotification": null,
          "EnableNotification": null,
          "EnableLocation": null,
          "AppCode": "5X5C-CB3U-6CUY",
          "HexCode": "8137a2174e1944c682589265fd1f911c_20190927100844",
          "CreateDate": "2019-09-27T10:08:43",
          "InDate": "2020-04-21T10:59:36",
          "OutDate": "0001-01-01T00:00:00",
          "Status": 2,
          "UserGuid": "Customer/20",
          "Visible": 1,
          "DeviceId": 31
        }
      ],
      "Region": null,
      "SystemTimeZoneInfo": null,
      "DeviceInfoGuid": "DeviceInfo/12",
      "Employees": [
        {
          "_Id": "Employee/16",
          "_rev": "_ZRz-jrO--_",
          "_key": 16,
          "FirstName": "Hoàng",
          "LastName": "Trần",
          [ x ]"FullName": "Hoàng Trần",
          "NameAcronymn": "H",
          "Avatar": "",[ x ]
          "DateOfBirth": "0001-01-01T00:00:00",
          "PassCode": "0011",
          "Email": "tranvuong@gmail.com",
          "Phone": "0874063454",
          "Department": 0,
          "Position": 0,
          "Country": 0,
          "City": 0,
          "Ward": 0
        },
        {
          "_Id": "Employee/17",
          "_rev": "_ZRztcIq--_",
          "_key": 17,
          "FirstName": "Ngọc",
          "LastName": "Lê",
          [ x ]"FullName": "Ngọc Lê",
          "NameAcronymn": "N",
          "Avatar": "",[ x ]
          "DateOfBirth": "0001-01-01T00:00:00",
          "PassCode": "6525",
          "Email": "ngocle@gmail.com",
          "Phone": "087604035456",
          "Department": 0,
          "Position": 0,
          "Country": 0,
          "City": 0,
          "Ward": 0
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

2. `api/pos/floor`
<br>

```json

{
  "Message": null,
  "DidError": false,
  "ErrorMessage": null,
  "Model": [
    {
      "Floor": [
        {
          "_Id": "Floor/2799851",
          "_rev": "_Z7E4AH----",
          "_key": 2799851,
          "FloorId": 30,
          "FloorCode": "00000u",
          "Name": "F 1",
          "Handle": "f-1",
          "LocationGuid": "Location/17",
          "Description": null,
          "UserGuid": "Customer/20",
          "CreateDate": "2020-01-31T09:14:05",
          "OrderNo": 0,
          "Visible": 1
        },
        {
          "_Id": "Floor/2799865",
          "_rev": "_Z7E4P5u---",
          "_key": 2799865,
          "FloorId": 31,
          "FloorCode": "00000v",
          "Name": "F 2",
          "Handle": "f-2",
          "LocationGuid": "Location/17",
          "Description": null,
          "UserGuid": "Customer/20",
          "CreateDate": "2020-01-31T09:14:22",
          "OrderNo": 0,
          "Visible": 1
        },
        {
          "_Id": "Floor/2799874",
          "_rev": "_Z7E4WhK---",
          "_key": 2799874,
          "FloorId": 32,
          "FloorCode": "00000w",
          "Name": "F 3",
          "Handle": "f-3",
          "LocationGuid": "Location/17",
          "Description": null,
          "UserGuid": "Customer/20",
          "CreateDate": "2020-01-31T09:14:28",
          "OrderNo": 0,
          "Visible": 1
        },
        {
          "_Id": "Floor/2799883",
          "_rev": "_Z7E4eUu---",
          "_key": 2799883,
          "FloorId": 33,
          "FloorCode": "00000x",
          "Name": "F 4",
          "Handle": "f-4",
          "LocationGuid": "Location/17",
          "Description": null,
          "UserGuid": "Customer/20",
          "CreateDate": "2020-01-31T09:14:36",
          "OrderNo": 0,
          "Visible": 1
        }
      ],
      "FloorTable": [
        {
          "_Id": "FloorTable/2800227",
          "_rev": "_Z7F_moa---",
          "_key": 2800227,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 3,
          "SectionGuid": "SectionTable/2800036",
          "TableName": "B2",
          "PeopleQuantity": 0,
          "Left": 90.0,
          "Top": 368.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 1,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800229",
          "_rev": "_Z7F_msW---",
          "_key": 2800229,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 3,
          "SectionGuid": "SectionTable/2800038",
          "TableName": "B3",
          "PeopleQuantity": 0,
          "Left": 180.0,
          "Top": 368.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 2,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800231",
          "_rev": "_Z7F_mwy---",
          "_key": 2800231,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 3,
          "SectionGuid": "SectionTable/2800040",
          "TableName": "B4",
          "PeopleQuantity": 0,
          "Left": 0.0,
          "Top": 470.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 3,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800233",
          "_rev": "_Z7F_m1K---",
          "_key": 2800233,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 3,
          "SectionGuid": "SectionTable/2800042",
          "TableName": "B5",
          "PeopleQuantity": 0,
          "Left": 91.0,
          "Top": 469.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 4,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800235",
          "_rev": "_Z7F_m5i---",
          "_key": 2800235,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 3,
          "SectionGuid": "SectionTable/2800068",
          "TableName": "B6",
          "PeopleQuantity": 0,
          "Left": 180.0,
          "Top": 470.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 5,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800237",
          "_rev": "_Z7F_m9W---",
          "_key": 2800237,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 1,
          "SectionGuid": "SectionTable/2800115",
          "TableName": "D1",
          "PeopleQuantity": 0,
          "Left": 493.0,
          "Top": 80.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 6,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800239",
          "_rev": "_Z7F_nFm---",
          "_key": 2800239,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 1,
          "SectionGuid": "SectionTable/2800117",
          "TableName": "D2",
          "PeopleQuantity": 0,
          "Left": 583.0,
          "Top": 80.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 7,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800241",
          "_rev": "_Z7F_nJq---",
          "_key": 2800241,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 1,
          "SectionGuid": "SectionTable/2800119",
          "TableName": "D3",
          "PeopleQuantity": 0,
          "Left": 673.0,
          "Top": 80.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 8,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800243",
          "_rev": "_Z7F_nNy---",
          "_key": 2800243,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 1,
          "SectionGuid": "SectionTable/2800127",
          "TableName": "D7",
          "PeopleQuantity": 0,
          "Left": 494.0,
          "Top": 269.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 9,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800245",
          "_rev": "_Z7F_nS----",
          "_key": 2800245,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 1,
          "SectionGuid": "SectionTable/2800129",
          "TableName": "D8",
          "PeopleQuantity": 0,
          "Left": 585.0,
          "Top": 269.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 10,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800247",
          "_rev": "_Z7F_nWK---",
          "_key": 2800247,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 1,
          "SectionGuid": "SectionTable/2800121",
          "TableName": "D4",
          "PeopleQuantity": 0,
          "Left": 494.0,
          "Top": 172.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 11,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800249",
          "_rev": "_Z7F_na----",
          "_key": 2800249,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 1,
          "SectionGuid": "SectionTable/2800123",
          "TableName": "D5",
          "PeopleQuantity": 0,
          "Left": 584.0,
          "Top": 171.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 12,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800251",
          "_rev": "_Z7F_nd2---",
          "_key": 2800251,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 1,
          "SectionGuid": "SectionTable/2800125",
          "TableName": "D6",
          "PeopleQuantity": 0,
          "Left": 675.0,
          "Top": 173.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 13,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800253",
          "_rev": "_Z7F_nmi---",
          "_key": 2800253,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 1,
          "SectionGuid": "SectionTable/2800131",
          "TableName": "D9",
          "PeopleQuantity": 0,
          "Left": 677.0,
          "Top": 267.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 14,
          "Visible": 0,
          "UserGuid": "Customer/20"
        },
        {
          "_Id": "FloorTable/2800225",
          "_rev": "_aXo09ii--_",
          "_key": 2800225,
          "FloorGuid": "Floor/2799851",
          "TableTypeId": 3,
          "SectionGuid": "SectionTable/2800034",
          "TableName": "B1",
          "PeopleQuantity": 0,
          "Left": 0.0,
          "Top": 368.0,
          "Width": 80,
          "Height": 80,
          "CreateDate": "2020-01-31T09:22:23",
          "OrderNo": 0,
          "Visible": 0,
          "UserGuid": "Customer/20"
        }
      ],
      "TableType": [
        {
          "_Id": "TableType/2627189",
          "_rev": "_Z3ynwkK---",
          "_key": 2627189,
          "TableTypeId": 1,
          "Name_vi": "Hình Vuông",
          "Name_en": "Square",
          "Acronymn": "S",
          "Handle": "square",
          "Width": 100,
          "Height": 100,
          "OrderNo": 0,
          "Visible": 1
        },
        {
          "_Id": "TableType/2627191",
          "_rev": "_Z3ynwkK--C",
          "_key": 2627191,
          "TableTypeId": 3,
          "Name_vi": "Hình Tròn",
          "Name_en": "Circle",
          "Acronymn": "C",
          "Handle": "circle",
          "Width": 100,
          "Height": 100,
          "OrderNo": 2,
          "Visible": 1
        }
      ]
    }
  ],
  "PageSize": 0,
  "PageNumber": 0,
  "ItemsCount": 0,
  "PageCount": -2147483648.0
}{
  "Message": null,
  "DidError": false,
  "ErrorMessage": null,
  "Model": [
    {
      "Device": [
        {
          "_Id": "Device/76",
          "_rev": "_aXpidW---_",
          "_key": 76,
          "Nickname": "Cashier",
          "Location": "Location/17",
          "DeviceType": 1,
          "RequestNotification": null,
          "EnableNotification": null,
          "EnableLocation": null,
          "AppCode": "5X5C-CB3U-6CUY",
          "HexCode": "8137a2174e1944c682589265fd1f911c_20190927100844",
          "CreateDate": "2019-09-27T10:08:43",
          "InDate": "2020-04-21T10:59:36",
          "OutDate": "0001-01-01T00:00:00",
          "Status": 2,
          "UserGuid": "Customer/20",
          "Visible": 1,
          "DeviceId": 31
        }
      ],
      "Region": null,
      "SystemTimeZoneInfo": null,
      "DeviceInfoGuid": "DeviceInfo/12",
      "Employees": [
        {
          "_Id": "Employee/16",
          "_rev": "_ZRz-jrO--_",
          "_key": 16,
          "FirstName": "Hoàng",
          "LastName": "Trần",
          "FullName": "Hoàng Trần",
          "NameAcronymn": "H",
          "Avatar": "",
          "DateOfBirth": "0001-01-01T00:00:00",
          "PassCode": "0011",
          "Email": "tranvuong@gmail.com",
          "Phone": "0874063454",
          "Department": 0,
          "Position": 0,
          "Country": 0,
          "City": 0,
          "Ward": 0
        },
        {
          "_Id": "Employee/17",
          "_rev": "_ZRztcIq--_",
          "_key": 17,
          "FirstName": "Ngọc",
          "LastName": "Lê",
          "FullName": "Ngọc Lê",
          "NameAcronymn": "N",
          "Avatar": "",
          "DateOfBirth": "0001-01-01T00:00:00",
          "PassCode": "6525",
          "Email": "ngocle@gmail.com",
          "Phone": "087604035456",
          "Department": 0,
          "Position": 0,
          "Country": 0,
          "City": 0,
          "Ward": 0
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
