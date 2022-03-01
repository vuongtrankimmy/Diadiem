# Địa Điểm API v3.2.1


### Cập nhật

## ``FRONTEND USER *[27/06/2020]* v3.2.1``
• **Discount** (3): Cập nhật thông tin Discounts. Cập nhật object ListSetSchedules, Chuyển đối tượng **TimeOn,TimeOff** từ Single đến Multiple và apply đến đối tượng **ListSetTime**

## ``FRONTEND USER *[26/06/2020]* v3.2``

• **Products** (1): Cập nhật thông tin Modifier

• **Taxes** (2): Cập nhật thông tin Taxes sử dụng cho item.

• **Discount** (3): Cập nhật thông tin Discounts. Thêm Object **ListDiscountsApplyToItem** để xác định Discounts được gắn tới sản phẩm phù hợp. **DiscountAutomatic** nếu =True: code này sẽ được tự động apply đến order,Fasle: code này sẽ yêu cầu nhập trong order.

• **ListDeviceType** (4): Loại hiển thị của thiết bị. Sử dụng để tắt/mở chức năng và custom giao diện phù hợp với thiết bị

• **api/orders** (5): Hiển thị thông tin orders và cập nhật thông tin order

(1)
```
 "Modifier": "[{\"ModifierGuid\":\"Modifier/438214104\",\"ModifierName\":\"Pizza extra\"}]"
```

(2)
```
 {"Message":null,"DidError":false,"ErrorMessage":null,"Model":[{"ListTaxes":[{"_id":"CustomerTax/10","_key":10,"Id":0,"Name":"Products","EnableTax":true,"TaxValue":0.0,"TaxIncludingMethodName":"","TaxIncludingMethodId":null}],"ListTaxesAssignToItem":null}]}
```

(3)
```
 ListDiscountsApplyToItem": [
        {
          "DiscountGuid": "CustomerDiscounts/9",
          "DiscountType": 4,
          "ApplyTo": 2,
          "ListParents": "",
          "ListProducts": "[{\"ProductGuid\":\"Product/438210359\",\"ListVariant\":[{\"GroupName\":\"Pork\",\"OrderNo\":0},{\"GroupName\":\"Chicken\",\"OrderNo\":1}]},{\"ProductGuid\":\"Product/438210356\",\"ListVariant\":[{\"GroupName\":\"Rare\",\"OrderNo\":0},{\"GroupName\":\"Medium\",\"OrderNo\":1},{\"GroupName\":\"Welldone\",\"OrderNo\":2}]},{\"ProductGuid\":\"Product/438210353\",\"ListVariant\":[{\"GroupName\":\"Rare•Mushroom sauce\",\"OrderNo\":0},{\"GroupName\":\"Rare•Pepper sauce\",\"OrderNo\":1},{\"GroupName\":\"Rare•Red wine sauce\",\"OrderNo\":2},{\"GroupName\":\"Medium•Mushroom sauce\",\"OrderNo\":3},{\"GroupName\":\"Medium•Pepper sauce\",\"OrderNo\":4},{\"GroupName\":\"Medium•Red wine sauce\",\"OrderNo\":5},{\"GroupName\":\"Well done•Mushroom sauce\",\"OrderNo\":6},{\"GroupName\":\"Well done•Pepper sauce\",\"OrderNo\":7},{\"GroupName\":\"Well done•Red wine sauce\",\"OrderNo\":8}]},{\"ProductGuid\":\"Product/438210345\",\"ListVariant\":[{\"GroupName\":\"Ba;samic - olive oil\",\"OrderNo\":0},{\"GroupName\":\"Mustard sauce (w/olive oil - lemon)\",\"OrderNo\":1}]},{\"ProductGuid\":\"Product/438210329\",\"ListVariant\":[{\"GroupName\":\"Caesar sauce (w/ anchovies)\",\"OrderNo\":0},{\"GroupName\":\"More caesar sauce (w/ anchovies)\",\"OrderNo\":1},{\"GroupName\":\"Add 1 more box caesar sauce (w/ anchovies)\",\"OrderNo\":2}]},{\"ProductGuid\":\"Product/438210293\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/438210292\",\"ListVariant\":[{\"GroupName\":\"Sandwich•French fries•Mayonnaise sauce\",\"OrderNo\":0},{\"GroupName\":\"Sandwich•French fries•No mayonnaise\",\"OrderNo\":1},{\"GroupName\":\"Sandwich•French fries•More tartar sauce by side\",\"OrderNo\":2},{\"GroupName\":\"Sandwich•French fries•Add 1 more box of tartar sauce by side\",\"OrderNo\":3},{\"GroupName\":\"Sandwich•Salad•Mayonnaise sauce\",\"OrderNo\":4},{\"GroupName\":\"Sandwich•Salad•No mayonnaise\",\"OrderNo\":5},{\"GroupName\":\"Sandwich•Salad•More tartar sauce by side\",\"OrderNo\":6},{\"GroupName\":\"Sandwich•Salad•Add 1 more box of tartar sauce by side\",\"OrderNo\":7},{\"GroupName\":\"Bugutte•French fries•Mayonnaise sauce\",\"OrderNo\":8},{\"GroupName\":\"Bugutte•French fries•No mayonnaise\",\"OrderNo\":9},{\"GroupName\":\"Bugutte•French fries•More tartar sauce by side\",\"OrderNo\":10},{\"GroupName\":\"Bugutte•French fries•Add 1 more box of tartar sauce by side\",\"OrderNo\":11},{\"GroupName\":\"Bugutte•Salad•Mayonnaise sauce\",\"OrderNo\":12},{\"GroupName\":\"Bugutte•Salad•No mayonnaise\",\"OrderNo\":13},{\"GroupName\":\"Bugutte•Salad•More tartar sauce by side\",\"OrderNo\":14},{\"GroupName\":\"Bugutte•Salad•Add 1 more box of tartar sauce by side\",\"OrderNo\":15}]},{\"ProductGuid\":\"Product/438210291\",\"ListVariant\":[{\"GroupName\":\"Sandwich•French fries•Mayonnaise sauce\",\"OrderNo\":0},{\"GroupName\":\"Sandwich•French fries•No mayonnaise\",\"OrderNo\":1},{\"GroupName\":\"Sandwich•French fries•More tartar sauce by side\",\"OrderNo\":2},{\"GroupName\":\"Sandwich•Salad•Mayonnaise sauce\",\"OrderNo\":3},{\"GroupName\":\"Sandwich•Salad•No mayonnaise\",\"OrderNo\":4},{\"GroupName\":\"Sandwich•Salad•More tartar sauce by side\",\"OrderNo\":5},{\"GroupName\":\"Bagutte•French fries•Mayonnaise sauce\",\"OrderNo\":6},{\"GroupName\":\"Bagutte•French fries•No mayonnaise\",\"OrderNo\":7},{\"GroupName\":\"Bagutte•French fries•More tartar sauce by side\",\"OrderNo\":8},{\"GroupName\":\"Bagutte•Salad•Mayonnaise sauce\",\"OrderNo\":9},{\"GroupName\":\"Bagutte•Salad•No mayonnaise\",\"OrderNo\":10},{\"GroupName\":\"Bagutte•Salad•More tartar sauce by side\",\"OrderNo\":11}]},{\"ProductGuid\":\"Product/438210290\",\"ListVariant\":[{\"GroupName\":\"Sandwich•French fries•Mayonnaise sauce\",\"OrderNo\":0},{\"GroupName\":\"Sandwich•French fries•No mayonnaise\",\"OrderNo\":1},{\"GroupName\":\"Sandwich•French fries•More tartar sauce by side\",\"OrderNo\":2},{\"GroupName\":\"Sandwich•French fries•Add 1 more box of tartar sauce by side\",\"OrderNo\":3},{\"GroupName\":\"Sandwich•Salad•Mayonnaise sauce\",\"OrderNo\":4},{\"GroupName\":\"Sandwich•Salad•No mayonnaise\",\"OrderNo\":5},{\"GroupName\":\"Sandwich•Salad•More tartar sauce by side\",\"OrderNo\":6},{\"GroupName\":\"Sandwich•Salad•Add 1 more box of tartar sauce by side\",\"OrderNo\":7},{\"GroupName\":\"Bagutte•French fries•Mayonnaise sauce\",\"OrderNo\":8},{\"GroupName\":\"Bagutte•French fries•No mayonnaise\",\"OrderNo\":9},{\"GroupName\":\"Bagutte•French fries•More tartar sauce by side\",\"OrderNo\":10},{\"GroupName\":\"Bagutte•French fries•Add 1 more box of tartar sauce by side\",\"OrderNo\":11},{\"GroupName\":\"Bagutte•Salad•Mayonnaise sauce\",\"OrderNo\":12},{\"GroupName\":\"Bagutte•Salad•No mayonnaise\",\"OrderNo\":13},{\"GroupName\":\"Bagutte•Salad•More tartar sauce by side\",\"OrderNo\":14},{\"GroupName\":\"Bagutte•Salad•Add 1 more box of tartar sauce by side\",\"OrderNo\":15}]},{\"ProductGuid\":\"Product/438210289\",\"ListVariant\":[{\"GroupName\":\"Sandwich•French fries•Mayonnaise sauce\",\"OrderNo\":0},{\"GroupName\":\"Sandwich•French fries•No mayonnaise\",\"OrderNo\":1},{\"GroupName\":\"Sandwich•French fries•More tartar sauce by side\",\"OrderNo\":2},{\"GroupName\":\"Sandwich•French fries•Add 1 more box of tartar sauce by side\",\"OrderNo\":3},{\"GroupName\":\"Sandwich•Salad•Mayonnaise sauce\",\"OrderNo\":4},{\"GroupName\":\"Sandwich•Salad•No mayonnaise\",\"OrderNo\":5},{\"GroupName\":\"Sandwich•Salad•More tartar sauce by side\",\"OrderNo\":6},{\"GroupName\":\"Sandwich•Salad•Add 1 more box of tartar sauce by side\",\"OrderNo\":7},{\"GroupName\":\"Bagutte•French fries•Mayonnaise sauce\",\"OrderNo\":8},{\"GroupName\":\"Bagutte•French fries•No mayonnaise\",\"OrderNo\":9},{\"GroupName\":\"Bagutte•French fries•More tartar sauce by side\",\"OrderNo\":10},{\"GroupName\":\"Bagutte•French fries•Add 1 more box of tartar sauce by side\",\"OrderNo\":11},{\"GroupName\":\"Bagutte•Salad•Mayonnaise sauce\",\"OrderNo\":12},{\"GroupName\":\"Bagutte•Salad•No mayonnaise\",\"OrderNo\":13},{\"GroupName\":\"Bagutte•Salad•More tartar sauce by side\",\"OrderNo\":14},{\"GroupName\":\"Bagutte•Salad•Add 1 more box of tartar sauce by side\",\"OrderNo\":15}]},{\"ProductGuid\":\"Product/438210288\",\"ListVariant\":[{\"GroupName\":\"Sandwich•Mayonnaise sauce\",\"OrderNo\":0},{\"GroupName\":\"Sandwich•No mayonnaise\",\"OrderNo\":1},{\"GroupName\":\"Sandwich•More tartar sauce by side\",\"OrderNo\":2},{\"GroupName\":\"Sandwich•Add 1 more box of tartar sauce by side\",\"OrderNo\":3},{\"GroupName\":\"Baguette•Mayonnaise sauce\",\"OrderNo\":4},{\"GroupName\":\"Baguette•No mayonnaise\",\"OrderNo\":5},{\"GroupName\":\"Baguette•More tartar sauce by side\",\"OrderNo\":6},{\"GroupName\":\"Baguette•Add 1 more box of tartar sauce by side\",\"OrderNo\":7}]}]",
          "UserGuid": "Customer/438227755"
        },
        {
          "DiscountGuid": "CustomerDiscounts/21",
          "DiscountType": 1,
          "ApplyTo": 3,
          "ListParents": "[{\"GroupGuid\":\"AccountGroup/28\"},{\"GroupGuid\":\"AccountGroup/25\"},{\"GroupGuid\":\"AccountGroup/24\"},{\"GroupGuid\":\"AccountGroup/21\"},{\"GroupGuid\":\"AccountGroup/20\"},{\"GroupGuid\":\"AccountGroup/19\"}]",
          "ListProducts": "[{\"ProductGuid\":\"Product/438210351\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/438210350\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/438210347\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/438210336\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/438210335\",\"ListVariant\":[]}]",
          "UserGuid": "Customer/438227755"
        },
        {
          "DiscountGuid": "CustomerDiscounts/10",
          "DiscountType": 4,
          "ApplyTo": 2,
          "ListParents": "",
          "ListProducts": "[{\"ProductGuid\":\"Product/438210239\",\"ListVariant\":[]}]",
          "UserGuid": "Customer/438227755"
        }
      ]
```


(4)

```
ListDeviceType": [
        {
          "Id": 1,
          "Title": "Restaurant Table"
        },
        {
          "Id": 2,
          "Title": "Retaurant No Table"
        },
        {
          "Id": 3,
          "Title": "Shop"
        },
        {
          "Id": 4,
          "Title": "Spa"
        }
      ]
```

(5)

```
{
  "Message": null,
  "DidError": false,
  "ErrorMessage": null,
  "Model": [
    {
      "_key": "4",
      "_id": "Orders/4",
      "_rev": "_asPiCmi--A",
      "OrderGuid": "AXLhB7qpKhSfkzkwHdJA",
      "OrderId": 4,
      "OrderCode": "#SGM86694857",
      "Billing": {
        "Customer": {
          "Name": "Nicolai",
          "Email": "outrunshark462@gmail.com",
          "Phone": "0777791268",
          "Company": ""
        },
        "Address": {
          "CityId": 8,
          "CityName": "Hồ Chí Minh",
          "DistrictId": 31,
          "DistrictName": "2",
          "WardId": 684,
          "WardName": "Thảo Điền",
          "Street": "40/11 Xuan Thuy",
          "TypeAddressId": 1,
          "TypeAddress": "house",
          "TypeAddressInfo": "[]"
        }
      },
      "Shipping": {
        "Customer": {
          "Name": "Nicolai",
          "Email": "outrunshark462@gmail.com",
          "Phone": "0777791268",
          "Company": ""
        },
        "Address": {
          "CityId": 0,
          "CityName": "",
          "DistrictId": 0,
          "DistrictName": "",
          "WardId": 0,
          "WardName": "",
          "Street": "",
          "TypeAddressId": 0,
          "TypeAddress": "",
          "TypeAddressInfo": ""
        }
      },
      "OrderDetail": [
        {
          "OrderDetailId": 1,
          "OrderGuid": "AXLhB7qpKhSfkzkwHdJA",
          "ProductGuid": "AXLG86EQKhSfkzkwHdHr",
          "Name": "Salami piccante (spicy)",
          "Name1": "",
          "Sku": "",
          "Variants": "",
          "Url": "",
          "ListExtra": [
            {
              "Name": "Onion",
              "Url": "",
              "Price": 20000,
              "Quantity": 1,
              "Total": 20000
            }
          ],
          "ListPromotion": [
            
          ],
          "Price": 190000,
          "Quantity": 1,
          "Total": 190000,
          "LineTax": 0,
          "LineService": 0,
          "DiscountCode": "",
          "LineDiscount": 0,
          "LineTotal": 210000,
          "CreateDate": "2020/06/23 18:54:40",
          "Note": "",
          "Status": 1
        },
        {
          "OrderDetailId": 2,
          "OrderGuid": "AXLhB7qpKhSfkzkwHdJA",
          "ProductGuid": "AWoQ8jgbz8kMBxcmEkqq",
          "Name": "I do not want that",
          "Name1": "",
          "Sku": "",
          "Variants": "",
          "Url": "",
          "ListExtra": [
            
          ],
          "ListPromotion": [
            
          ],
          "Price": 95000,
          "Quantity": 1,
          "Total": 95000,
          "LineTax": 0,
          "LineService": 0,
          "DiscountCode": "",
          "LineDiscount": 0,
          "LineTotal": 95000,
          "CreateDate": "2020/06/23 18:54:40",
          "Note": "",
          "Status": 1
        }
      ],
      "SubTotal": 305000,
      "DiscountCode": "",
      "DiscountValue": 0,
      "Tax": 0,
      "ShippingFee": 0,
      "ServiceFee": 15250,
      "GrandTotal": 320250,
      "PaymentAmount": 0,
      "Balance": 305000,
      "Status": 1,
      "PaymentTypeId": 1,
      "PaymentType": "COD",
      "Notes": "",
      "CreateDate": "2020/06/23 18:54:40",
      "DeviceGuid": "Device/438231124",
      "LocationGuid": "Location/425242113",
      "UserGuid": "Customer/438227755",
      "EmployeeGuid": "Employee/3116129",
      "DeliveryTypeId": 2,
      "DeliveryType": "delivery",
      "OrderTime": null,
      "OrderTimeLater": null,
      "HourPickup": "",
      "Device": null
    }
  ]
}
```