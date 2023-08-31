/*Answer 1: $44897.64*******************/
[{
 $project: {
  mult: {
   $multiply: [
    '$saleprice',
    '$quantity'
   ]
  },
  add: {
   $sum: '$salestax'
  }
 }
}, {
 $project: {
  total_price: {
   $sum: [
    '$mult',
    '$add'
   ]
  }
 }
}, {
 $group: {
  _id: 0,
  fulltotal: {
   $sum: '$total_price'
  }
 }
}]
/*Answer 2: Dog-16566.72 *************************************************/
[{
    $sort: {
        saleprice: -1
    }
}, {
    $group: {
        _id: '$animal.category',
        count: {
            $sum: '$saleprice'
        }
    }
}, {
    $match: {
        _id: 'Dog'
    }
}]
/*Answer 3: "null" technically had the most with 1281, but the next highest was Dog with 95 **************************************/
[{
 $sort: {
  saleprice: -1
 }
}, {
 $group: {
  _id: '$animal.category',
  count: {
   $sum: '$quantity'
  }
 }
}]
/*Answer 4: KY-2417.12*****************************************************************/
[{
 $match: {
  'animal.category': 'Dog'
 }
}, {
 $group: {
  _id: '$customer.state',
  count: {
   $sum: '$quantity'
  },
  sales: {
   $sum: '$saleprice'
  }
 }
}]

/*Answer 5: KY, Bellevue-3, $501.169999 **************************************************************************/
[{
 $match: {
  'animal.category': 'Cat'
 }
}, {
 $match: {
  'customer.state': 'KY'
 }
}, {
 $group: {
  _id: {
   state: '$customer.state',
   city: '$customer.city'
  },
  count: {
   $sum: '$quantity'
  },
  sales: {
   $sum: '$saleprice'
  }
 }
}]
/*Answer 6: Spider ******************************************************************/
[{
 $sort: {
  saleprice: -1
 }
}, {
 $group: {
  _id: '$animal.category',
  price: {
   $sum: '$saleprice'
  },
  count: {
   $sum: '$quantity'
  }
 }
}, {
 $match: {
  _id: 'Spider'
 }
}]