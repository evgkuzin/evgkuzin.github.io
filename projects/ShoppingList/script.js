var button = document.getElementById('enter');
var input = document.getElementById('userinput');
var tr = document.querySelector('tr');
var tbody = document.querySelector('tbody');
var td = document.getElementsByTagName('td');

button.addEventListener('click', Onclick);
input.addEventListener('keypress', addElement);

tdEvent();
buttonListElement();

function checkInputlength(){
	return input.value.length;
}

function addButton(){
		var td = document.createElement("td");
		var arr = document.querySelectorAll("tr");
		var last = arr[arr.length-1];
		var button = document.createElement("button");
		td.appendChild(button);
		last.appendChild(td);
		button.innerHTML = "delete";
		button.className = "btn btn-sm btn-outline-danger";

}

function createListElement(){

		var td = document.createElement("td");
		var tr = document.createElement("tr");
		var tbody = document.querySelector("tbody");
		var button = document.createElement("button");
		td.appendChild(document.createTextNode(input.value));
		tr.appendChild(td);
		tbody.appendChild(tr);
		addButton();
		input.value = "";
}

function Onclick(){

	if(checkInputlength() > 0){
		createListElement();
	}

}

function addElement(){

	if(checkInputlength() > 0 && event.keyCode === 13){
		createListElement();
	}
}

function tdEvent(){
	for( i=0; i<td.length; i++){
	td[i].addEventListener('click', changeClass)
	}
}

function changeClass(){
	this.classList.toggle('done');
}

function buttonListElement(){
	var button = document.querySelectorAll('td button');
	for (i=0; i<button.length; i++){
	button[i].addEventListener('click', clearElement)
	}
}

function clearElement(){
	for(var i=0; i<td.length; i++){
		this.parentNode.parentNode.remove();
	}
}