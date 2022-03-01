# Địa Điểm API v3.1


### Cập nhật


## ``FRONTEND USER *[20/06/2020]*``

• **ListDiningOptions**: Lựa chọn ăn uống theo Location    

*   **ListVoid and ListComp** : Ghi chú lý do của order.

Example: **api/order/settings?UserGuid=Customer/20&LocationGuid=Location/18**


```
{
  "Message": null,
  "DidError": false,
  "ErrorMessage": null,
  "Model": [
    {
      "ListComp": [
        {
          "Id": 1,
          "GroupName": "Comp Reasons",
          "ListReasons": [
            {
              "Id": 1,
              "Title": "Entry error",
              "Visible": 1
            },
            {
              "Id": 2,
              "Title": "Customer changeed mind",
              "Visible": 1
            },
            {
              "Id": 3,
              "Title": "Customer compaint",
              "Visible": 1
            },
            {
              "Id": 4,
              "Title": "Friends and family",
              "Visible": 1
            },
            {
              "Id": 5,
              "Title": "Employee discount",
              "Visible": 1
            },
            {
              "Id": 6,
              "Title": "Manager special",
              "Visible": 1
            }
          ]
        }
      ],
      "ListVoid": [
        {
          "Id": 2,
          "GroupName": "Void Reasons",
          "ListReasons": [
            {
              "Id": 7,
              "Title": "Entry error",
              "Visible": 1
            },
            {
              "Id": 8,
              "Title": "Item no longer available",
              "Visible": 1
            },
            {
              "Id": 9,
              "Title": "Customer changed mind",
              "Visible": 1
            }
          ]
        }
      ],
      "ListDiningOptions": [
        {
          "Id": 4,
          "Title": "For Here",
          "OrderNo": 0
        },
        {
          "Id": 3,
          "Title": "To Go",
          "OrderNo": 1
        },
        {
          "Id": 2,
          "Title": "Delivery",
          "OrderNo": 2
        },
        {
          "Id": 1,
          "Title": "Pickup",
          "OrderNo": 3
        }
      ]
    }
  ]
}

```