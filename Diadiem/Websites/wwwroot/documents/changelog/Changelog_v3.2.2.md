# Địa Điểm API v3.2.2


### Cập nhật

## ``FRONTEND USER *[08/07/2020]* v3.2.2``
• **Discount** (1): Cập nhật thông tin Discounts. Cập nhật object Chỉ lấy những Discount với DiscountType:

    • (4): Buy X Get Y

    • (5): Combo (Beginning)

    • (6): Gift (Comming soon)

• **Taxes** (2): Remove object này (Lỗi thiếu object xử lý)

• **Fees** (3): Thêm mới Object để hiển thị thông tin tính cho Subtotal & Total của Order theo 2 Group
    
    • (1): Subtotal: Những Phí được tính theo sản phẩm/item

        •• (1): Shipping or Delivery
        
        •• (2): Discount
        
        •• (3): Service or Addon

        •• (4): Surcharge
        
        •• (5): Tax
        
        •• (6): NA
    
    • (2): Total: Những Phí được tính theo Order sau khi có Subtotal

        •• (7): Total Shipping or Delivery
        
        •• (8): Discount
        
        •• (9): Service or Addon

        •• (10): Surcharge
        
        •• (11): Tax
        
        •• (12): NA


    • (5): Combo (Beginning)

    • (6): Gift (Comming soon)

(2)
```
 {"Message":null,"DidError":false,"ErrorMessage":null,"Model":[{"ListTaxes":[{"_id":"CustomerTax/10","_key":10,"Id":0,"Name":"Products","EnableTax":true,"TaxValue":0.0,"TaxIncludingMethodName":"","TaxIncludingMethodId":null}],"ListTaxesAssignToItem":null}]}
```

(3)
```
{
  "Message": null,
  "DidError": false,
  "ErrorMessage": null,
  "Model": [
    {
      "GroupId": 1,
      "GroupTitle": "Subtotal",
      "ListSettings": [
        {
          "Id": 1,
          "Title": "Shipping Or Delivery",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 1,
          "Value": 0,
          "Lists": [
            
          ]
        },
        {
          "Id": 2,
          "Title": "Discount",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 1,
          "Value": 0,
          "Lists": [
            {
              "ListDiscounts": [
                {
                  "DiscountGuid": "CustomerDiscounts/12",
                  "DiscountName": "Giao hàng miễn phí",
                  "DiscountType": 3,
                  "DiscountAutomatic": true,
                  "Acronymn": "&AMP;NBSP;",
                  "Color": "#ddd",
                  "AssignTo": 1,
                  "DiscountCode": "SDP5H4",
                  "MinimumRequiredType": 2,
                  "MinimumRequired": "",
                  "CustomerEligibility": 1,
                  "UsageLimits": "[{\"Id\":1,\"Limit\":10},{\"Id\":2,\"Limit\":0}]",
                  "SetSchedules": 0,
                  "ListSchedules": "[]",
                  "DateRange": 0,
                  "DateOn": "",
                  "DateOff": ""
                },
                {
                  "DiscountGuid": "CustomerDiscounts/7",
                  "DiscountName": "Khuyến mãi",
                  "DiscountType": 1,
                  "DiscountAutomatic": true,
                  "Acronymn": "&AMP;NBSP;",
                  "Color": "#ddd",
                  "AssignTo": 1,
                  "DiscountCode": "99UB29",
                  "MinimumRequiredType": 2,
                  "MinimumRequired": "[{\"Id\":2,\"Value\":0}]",
                  "CustomerEligibility": 2,
                  "UsageLimits": "[{\"Id\":1,\"Limit\":20},{\"Id\":2,\"Limit\":0}]",
                  "SetSchedules": 0,
                  "ListSchedules": "[]",
                  "DateRange": 0,
                  "DateOn": "",
                  "DateOff": ""
                },
                {
                  "DiscountGuid": "CustomerDiscounts/9",
                  "DiscountName": "Khuyến mãi tháng 10",
                  "DiscountType": 2,
                  "DiscountAutomatic": true,
                  "Acronymn": "KMT",
                  "Color": "#4ea942",
                  "AssignTo": 1,
                  "DiscountCode": "JWS49D",
                  "MinimumRequiredType": 2,
                  "MinimumRequired": "[{\"Id\":2,\"Value\":0}]",
                  "CustomerEligibility": 2,
                  "UsageLimits": "[{\"Id\":1,\"Limit\":10},{\"Id\":2,\"Limit\":0}]",
                  "SetSchedules": 1,
                  "ListSchedules": "[{\"Id\":\"2\",\"Date\":\"Monday\",\"ListSetTime\":[{\"TimeOn\":\"12:56\",\"TimeOff\":\"13:52\",\"OrderNo\":0}]},{\"Id\":\"3\",\"Date\":\"Tuesday\",\"ListSetTime\":[{\"TimeOn\":\"01:52\",\"TimeOff\":\"20:54\",\"OrderNo\":0}]},{\"Id\":\"4\",\"Date\":\"Webnesday\",\"ListSetTime\":[{\"TimeOn\":\"12:51\",\"TimeOff\":\"17:55\",\"OrderNo\":0}]},{\"Id\":\"5\",\"Date\":\"Thursday\",\"ListSetTime\":[{\"TimeOn\":\"13:51\",\"TimeOff\":\"19:51\",\"OrderNo\":0}]},{\"Id\":\"6\",\"Date\":\"Friday\",\"ListSetTime\":[{\"TimeOn\":\"15:57\",\"TimeOff\":\"21:52\",\"OrderNo\":0}]},{\"Id\":\"7\",\"Date\":\"Saturday\",\"ListSetTime\":[{\"TimeOn\":\"16:52\",\"TimeOff\":\"20:52\",\"OrderNo\":0}]},{\"Id\":\"1\",\"Date\":\"Sunday\",\"ListSetTime\":[{\"TimeOn\":\"13:53\",\"TimeOff\":\"16:59\",\"OrderNo\":0}]}]",
                  "DateRange": 1,
                  "DateOn": "2020/05/06 08:00",
                  "DateOff": "2020/09/30 17:00"
                },
                {
                  "DiscountGuid": "CustomerDiscounts/5",
                  "DiscountName": "Chuong trinh giam gia 50%",
                  "DiscountType": 1,
                  "DiscountAutomatic": true,
                  "Acronymn": "CTGG",
                  "Color": "#ddd",
                  "AssignTo": 1,
                  "DiscountCode": "5GXKHU",
                  "MinimumRequiredType": 2,
                  "MinimumRequired": "[{\"Id\":2,\"Value\":0}]",
                  "CustomerEligibility": 1,
                  "UsageLimits": "[{\"Id\":1,\"Limit\":20},{\"Id\":2,\"Limit\":0}]",
                  "SetSchedules": 0,
                  "ListSchedules": "[]",
                  "DateRange": 0,
                  "DateOn": "",
                  "DateOff": ""
                }
              ],
              "ListDiscountsCondition": [
                {
                  "DiscountGuid": "CustomerDiscounts/12",
                  "DiscountType": 3,
                  "Conditions": [
                    {
                      "_Id": "Discounts_FreeShipping/3",
                      "_rev": "_as9Tdr2--_",
                      "_key": 3,
                      "DiscountGuid": "CustomerDiscounts/12",
                      "DiscountType": 3,
                      "AppliesTo": 1,
                      "OnlyApplyDiscount": 1,
                      "ListFromItem": "[{\"GroupGuid\":\"704\",\"Name\":\"Viet Nam\"}]"
                    }
                  ]
                },
                {
                  "DiscountGuid": "CustomerDiscounts/7",
                  "DiscountType": 1,
                  "Conditions": [
                    {
                      "_Id": "Discounts_Percentage/10",
                      "_rev": "_awyA67i--_",
                      "_key": 10,
                      "DiscountType": 1,
                      "DiscountGuid": "CustomerDiscounts/7",
                      "DiscountValue": 0.0,
                      "AppliesTo": 4,
                      "ListFromItem": "[{\"CategoryGuid\":\"Category/1329628\",\"Name\":\"Pizza\"},{\"CategoryGuid\":\"Category/1329667\",\"Name\":\"Pendogo - Lunch Set\"},{\"CategoryGuid\":\"Category/1329659\",\"Name\":\"Buy 1 Get 1 Free\"},{\"CategoryGuid\":\"Category/1329663\",\"Name\":\"Kids Menu\"},{\"CategoryGuid\":\"Category/1329657\",\"Name\":\"Special Of The Month\"},{\"CategoryGuid\":\"Category/1329631\",\"Name\":\"Appetizers\"},{\"CategoryGuid\":\"Category/1329633\",\"Name\":\"Homemade Pasta\"},{\"CategoryGuid\":\"Category/1329635\",\"Name\":\"Pasta\"},{\"CategoryGuid\":\"Category/1329641\",\"Name\":\"Soup\"},{\"CategoryGuid\":\"Category/1329643\",\"Name\":\"Risotti\"},{\"CategoryGuid\":\"Category/1329645\",\"Name\":\"Main Course\"},{\"CategoryGuid\":\"Category/1329647\",\"Name\":\"Side Dishes\"},{\"CategoryGuid\":\"Category/1329649\",\"Name\":\"Sandwich\"},{\"CategoryGuid\":\"Category/1329651\",\"Name\":\"Dessert\"},{\"CategoryGuid\":\"Category/1329653\",\"Name\":\"Special\"},{\"CategoryGuid\":\"Category/1329655\",\"Name\":\"Drinks & Beer\"}]"
                    }
                  ]
                },
                {
                  "DiscountGuid": "CustomerDiscounts/9",
                  "DiscountType": 2,
                  "Conditions": [
                    {
                      "_Id": "Discounts_FixedAmount/2",
                      "_rev": "_awyLwEO--_",
                      "_key": 2,
                      "DiscountGuid": "CustomerDiscounts/9",
                      "DiscountType": 2,
                      "DiscountValue": 30000.0,
                      "AppliesTo": 3,
                      "ListFromItem": "[{\"GroupGuid\":\"AccountGroup/59\",\"Name\":\"Dessert\"},{\"GroupGuid\":\"AccountGroup/55\",\"Name\":\"Monday Meatless Discount\"},{\"GroupGuid\":\"AccountGroup/54\",\"Name\":\"khuyen mai\"},{\"GroupGuid\":\"AccountGroup/51\",\"Name\":\"Top 10 Pasta Discount\"}]"
                    }
                  ]
                },
                {
                  "DiscountGuid": "CustomerDiscounts/5",
                  "DiscountType": 1,
                  "Conditions": [
                    {
                      "_Id": "Discounts_Percentage/12",
                      "_rev": "_awyMjqi--_",
                      "_key": 12,
                      "DiscountType": 1,
                      "DiscountGuid": "CustomerDiscounts/5",
                      "DiscountValue": 20.0,
                      "AppliesTo": 2,
                      "ListFromItem": "[{\"ProductGuid\":\"Product/27\",\"Name\":\"Pizza - Go\",\"ListVariant\":[],\"TotalVariant\":0,\"TotalVariantChecked\":0},{\"ProductGuid\":\"Product/22\",\"Name\":\"Pendo - Dinner\",\"ListVariant\":[],\"TotalVariant\":0,\"TotalVariantChecked\":0},{\"ProductGuid\":\"Product/21\",\"Name\":\"Appetizers\",\"ListVariant\":[],\"TotalVariant\":0,\"TotalVariantChecked\":0},{\"ProductGuid\":\"Product/20\",\"Name\":\"Pizza - Dinner\",\"ListVariant\":[{\"GroupName\":\"S•White\",\"OrderNo\":0},{\"GroupName\":\"S•Black\",\"OrderNo\":1},{\"GroupName\":\"M•White\",\"OrderNo\":2},{\"GroupName\":\"M•Black\",\"OrderNo\":3},{\"GroupName\":\"L•White\",\"OrderNo\":4},{\"GroupName\":\"L•Black\",\"OrderNo\":5}],\"TotalVariant\":6,\"TotalVariantChecked\":6},{\"ProductGuid\":\"Product/19\",\"Name\":\"Lasagne classica\",\"ListVariant\":[{\"GroupName\":\"S•White\",\"OrderNo\":0},{\"GroupName\":\"S•Black\",\"OrderNo\":1},{\"GroupName\":\"S•Blue\",\"OrderNo\":2},{\"GroupName\":\"M•White\",\"OrderNo\":3},{\"GroupName\":\"M•Black\",\"OrderNo\":4},{\"GroupName\":\"M•Blue\",\"OrderNo\":5},{\"GroupName\":\"L•White\",\"OrderNo\":6},{\"GroupName\":\"L•Black\",\"OrderNo\":7},{\"GroupName\":\"L•Blue\",\"OrderNo\":8}],\"TotalVariant\":9,\"TotalVariantChecked\":9},{\"ProductGuid\":\"Product/12\",\"Name\":\"BEEF STEAK\",\"ListVariant\":[{\"GroupName\":\"Sandwich\",\"OrderNo\":0},{\"GroupName\":\"Bagutte\",\"OrderNo\":1}],\"TotalVariant\":2,\"TotalVariantChecked\":2},{\"ProductGuid\":\"Product/11\",\"Name\":\"Parma Ham\",\"ListVariant\":[{\"GroupName\":\"Sandwich\",\"OrderNo\":0},{\"GroupName\":\"Bagutte\",\"OrderNo\":1}],\"TotalVariant\":2,\"TotalVariantChecked\":2},{\"ProductGuid\":\"Product/10\",\"Name\":\"Ortolano\",\"ListVariant\":[{\"GroupName\":\"S•Red\",\"OrderNo\":0},{\"GroupName\":\"S•Blue\",\"OrderNo\":1},{\"GroupName\":\"S•Green\",\"OrderNo\":2},{\"GroupName\":\"M•Red\",\"OrderNo\":3},{\"GroupName\":\"M•Blue\",\"OrderNo\":4},{\"GroupName\":\"M•Green\",\"OrderNo\":5},{\"GroupName\":\"L•Red\",\"OrderNo\":6},{\"GroupName\":\"L•Blue\",\"OrderNo\":7},{\"GroupName\":\"L•Green\",\"OrderNo\":8},{\"GroupName\":\"XL•Red\",\"OrderNo\":9},{\"GroupName\":\"XL•Blue\",\"OrderNo\":10},{\"GroupName\":\"XL•Green\",\"OrderNo\":11}],\"TotalVariant\":12,\"TotalVariantChecked\":12}]"
                    }
                  ]
                }
              ],
              "ListDiscountsApplyToItem": [
                {
                  "DiscountGuid": "CustomerDiscounts/7",
                  "DiscountType": 1,
                  "ApplyTo": 4,
                  "ListParents": "[{\"CategoryGuid\":\"Category/1329628\"},{\"CategoryGuid\":\"Category/1329667\"},{\"CategoryGuid\":\"Category/1329659\"},{\"CategoryGuid\":\"Category/1329663\"},{\"CategoryGuid\":\"Category/1329657\"},{\"CategoryGuid\":\"Category/1329631\"},{\"CategoryGuid\":\"Category/1329633\"},{\"CategoryGuid\":\"Category/1329635\"},{\"CategoryGuid\":\"Category/1329641\"},{\"CategoryGuid\":\"Category/1329643\"},{\"CategoryGuid\":\"Category/1329645\"},{\"CategoryGuid\":\"Category/1329647\"},{\"CategoryGuid\":\"Category/1329649\"},{\"CategoryGuid\":\"Category/1329651\"},{\"CategoryGuid\":\"Category/1329653\"},{\"CategoryGuid\":\"Category/1329655\"}]",
                  "ListProducts": "[{\"ProductGuid\":\"Product/28\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/46\",\"ListVariant\":[]}]",
                  "UserGuid": "Customer/20"
                },
                {
                  "DiscountGuid": "CustomerDiscounts/9",
                  "DiscountType": 2,
                  "ApplyTo": 3,
                  "ListParents": "[{\"GroupGuid\":\"AccountGroup/59\"},{\"GroupGuid\":\"AccountGroup/55\"},{\"GroupGuid\":\"AccountGroup/54\"},{\"GroupGuid\":\"AccountGroup/51\"}]",
                  "ListProducts": "[{\"ProductGuid\":\"Product/12\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/28\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/11\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/16\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/13\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/26\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/26\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/27\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/46\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/46\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/48\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/48\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/49\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/49\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/11\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/16\",\"ListVariant\":[]}]",
                  "UserGuid": "Customer/20"
                },
                {
                  "DiscountGuid": "CustomerDiscounts/5",
                  "DiscountType": 1,
                  "ApplyTo": 2,
                  "ListParents": "",
                  "ListProducts": "[{\"ProductGuid\":\"Product/27\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/22\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/21\",\"ListVariant\":[]},{\"ProductGuid\":\"Product/20\",\"ListVariant\":[{\"GroupName\":\"S•White\",\"OrderNo\":0},{\"GroupName\":\"S•Black\",\"OrderNo\":1},{\"GroupName\":\"M•White\",\"OrderNo\":2},{\"GroupName\":\"M•Black\",\"OrderNo\":3},{\"GroupName\":\"L•White\",\"OrderNo\":4},{\"GroupName\":\"L•Black\",\"OrderNo\":5}]},{\"ProductGuid\":\"Product/19\",\"ListVariant\":[{\"GroupName\":\"S•White\",\"OrderNo\":0},{\"GroupName\":\"S•Black\",\"OrderNo\":1},{\"GroupName\":\"S•Blue\",\"OrderNo\":2},{\"GroupName\":\"M•White\",\"OrderNo\":3},{\"GroupName\":\"M•Black\",\"OrderNo\":4},{\"GroupName\":\"M•Blue\",\"OrderNo\":5},{\"GroupName\":\"L•White\",\"OrderNo\":6},{\"GroupName\":\"L•Black\",\"OrderNo\":7},{\"GroupName\":\"L•Blue\",\"OrderNo\":8}]},{\"ProductGuid\":\"Product/12\",\"ListVariant\":[{\"GroupName\":\"Sandwich\",\"OrderNo\":0},{\"GroupName\":\"Bagutte\",\"OrderNo\":1}]},{\"ProductGuid\":\"Product/11\",\"ListVariant\":[{\"GroupName\":\"Sandwich\",\"OrderNo\":0},{\"GroupName\":\"Bagutte\",\"OrderNo\":1}]},{\"ProductGuid\":\"Product/10\",\"ListVariant\":[{\"GroupName\":\"S•Red\",\"OrderNo\":0},{\"GroupName\":\"S•Blue\",\"OrderNo\":1},{\"GroupName\":\"S•Green\",\"OrderNo\":2},{\"GroupName\":\"M•Red\",\"OrderNo\":3},{\"GroupName\":\"M•Blue\",\"OrderNo\":4},{\"GroupName\":\"M•Green\",\"OrderNo\":5},{\"GroupName\":\"L•Red\",\"OrderNo\":6},{\"GroupName\":\"L•Blue\",\"OrderNo\":7},{\"GroupName\":\"L•Green\",\"OrderNo\":8},{\"GroupName\":\"XL•Red\",\"OrderNo\":9},{\"GroupName\":\"XL•Blue\",\"OrderNo\":10},{\"GroupName\":\"XL•Green\",\"OrderNo\":11}]}]",
                  "UserGuid": "Customer/20"
                }
              ],
              "ListDiscountsImages": [
                
              ],
              "ListSystemDiscountType": [
                {
                  "DiscountType": 1,
                  "Title_vi": "Phần Trăm",
                  "Title_en": "Percentage",
                  "OrderNo": 0
                },
                {
                  "DiscountType": 2,
                  "Title_vi": "Số tiền",
                  "Title_en": "Fixed amount",
                  "OrderNo": 1
                },
                {
                  "DiscountType": 3,
                  "Title_vi": "Miễn Phí vận chuyển",
                  "Title_en": "Free shipping",
                  "OrderNo": 2
                },
                {
                  "DiscountType": 4,
                  "Title_vi": "Mua X tặng Y",
                  "Title_en": "Buy X get Y",
                  "OrderNo": 3
                }
              ],
              "ListApplyTo": [
                {
                  "Id": 1,
                  "Title": "Entire Order"
                },
                {
                  "Id": 2,
                  "Title": "Specific products"
                },
                {
                  "Id": 3,
                  "Title": "Specific collections"
                },
                {
                  "Id": 4,
                  "Title": "Specific categories"
                }
              ]
            }
          ]
        },
        {
          "Id": 3,
          "Title": "Service or Addon",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 1,
          "Value": 0,
          "Lists": [
            {
              "ListServices": [
                {
                  "ServiceGuid": "CustomerService/2",
                  "_key": 2,
                  "ServiceId": 1,
                  "Name": "Service 5 not Include",
                  "ServiceValue": 5.0,
                  "ServiceIncludingMethodName": "Add Service to Item Price"
                },
                {
                  "ServiceGuid": "CustomerService/1",
                  "_key": 1,
                  "ServiceId": 2,
                  "Name": "Phi 5",
                  "ServiceValue": 5.0,
                  "ServiceIncludingMethodName": "Include Service in Item Price"
                }
              ],
              "AppplyTo": [
                {
                  "_Id": "CustomerServiceProduct/1",
                  "_rev": "_awyVk-C--_",
                  "_key": 1,
                  "ServiceGuid": "CustomerService/1",
                  "AvailableAtFuture": 1,
                  "ListProduct": "[{\"ProductGuid\":\"Product/46\",\"Visible\":1},{\"ProductGuid\":\"Product/28\",\"Visible\":1},{\"ProductGuid\":\"Product/20\",\"Visible\":1},{\"ProductGuid\":\"Product/16\",\"Visible\":1},{\"ProductGuid\":\"Product/15\",\"Visible\":1},{\"ProductGuid\":\"Product/14\",\"Visible\":1},{\"ProductGuid\":\"Product/13\",\"Visible\":1},{\"ProductGuid\":\"Product/12\",\"Visible\":1},{\"ProductGuid\":\"Product/11\",\"Visible\":1},{\"ProductGuid\":\"Product/10\",\"Visible\":1},{\"ProductGuid\":\"Product/9\",\"Visible\":1}]"
                },
                {
                  "_Id": "CustomerServiceProduct/2",
                  "_rev": "_awyVP2G--_",
                  "_key": 2,
                  "ServiceGuid": "CustomerService/2",
                  "AvailableAtFuture": 1,
                  "ListProduct": "[{\"ProductGuid\":\"Product/24\",\"Visible\":1},{\"ProductGuid\":\"Product/23\",\"Visible\":1},{\"ProductGuid\":\"Product/15\",\"Visible\":1},{\"ProductGuid\":\"Product/14\",\"Visible\":1},{\"ProductGuid\":\"Product/13\",\"Visible\":1},{\"ProductGuid\":\"Product/12\",\"Visible\":1},{\"ProductGuid\":\"Product/11\",\"Visible\":1},{\"ProductGuid\":\"Product/10\",\"Visible\":1},{\"ProductGuid\":\"Product/9\",\"Visible\":1}]"
                }
              ]
            }
          ]
        },
        {
          "Id": 4,
          "Title": "Surcharge",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 1,
          "Value": 0,
          "Lists": [
            {
              "ListSurcharges": [
                {
                  "SurchargeGuid": "CustomerSurcharge/1",
                  "_key": 1,
                  "SurchargeId": 1,
                  "Name": "Surcharge 5 Include",
                  "SurchargeValue": 5.0,
                  "SurchargeIncludingMethodName": "Add Surcharge to Item Price"
                }
              ],
              "ApplyTo": [
                {
                  "_Id": "CustomerSurchargeProduct/1",
                  "_rev": "_awyVuU2--_",
                  "_key": 1,
                  "SurchargeGuid": "CustomerSurcharge/1",
                  "AvailableAtFuture": 1,
                  "ListProduct": "[{\"ProductGuid\":\"Product/13\",\"Visible\":1},{\"ProductGuid\":\"Product/12\",\"Visible\":1},{\"ProductGuid\":\"Product/11\",\"Visible\":1},{\"ProductGuid\":\"Product/10\",\"Visible\":1},{\"ProductGuid\":\"Product/9\",\"Visible\":1}]"
                }
              ]
            }
          ]
        },
        {
          "Id": 5,
          "Title": "Tax",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 1,
          "Value": 0,
          "Lists": [
            {
              "ListTaxes": [
                {
                  "TaxGuid": "CustomerTax/5622840",
                  "_key": 5622840,
                  "TaxId": 1,
                  "Name": "Tax 5",
                  "TaxValue": 5.0,
                  "TaxIncludingMethodName": "Add Tax to Item Price"
                }
              ],
              "AppplyTo": [
                
              ]
            }
          ]
        },
        {
          "Id": 6,
          "Title": "NA",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 0,
          "Value": 0,
          "Lists": [
            
          ]
        }
      ]
    },
    {
      "GroupId": 2,
      "GroupTitle": "Total",
      "ListSettings": [
        {
          "Id": 7,
          "Title": "Total Shipping",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 0,
          "Value": 0,
          "Lists": [
            
          ]
        },
        {
          "Id": 8,
          "Title": "Discount",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 0,
          "Value": 0,
          "Lists": [
            
          ]
        },
        {
          "Id": 9,
          "Title": "Service or Addon",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 0,
          "Value": 0,
          "Lists": [
            
          ]
        },
        {
          "Id": 10,
          "Title": "Surcharge",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 0,
          "Value": 0,
          "Lists": [
            
          ]
        },
        {
          "Id": 11,
          "Title": "Tax",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 0,
          "Value": 0,
          "Lists": [
            
          ]
        },
        {
          "Id": 12,
          "Title": "NA",
          "Plus": 1,
          "PlusText": "+",
          "Type": 1,
          "Visible": 0,
          "Value": 0,
          "Lists": [
            
          ]
        }
      ]
    }
  ]
}
```