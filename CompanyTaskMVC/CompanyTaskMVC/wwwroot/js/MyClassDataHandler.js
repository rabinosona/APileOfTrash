var callingDoc = document.querySelector('script[data-json][data-name="json"]')
var json = callingDoc.getAttribute('data-json')

function outerFileFunction(json)
{   
    alert(json)
}

outerFileFunction(json)