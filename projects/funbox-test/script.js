var item = document.getElementsByClassName('card-body');

itemEvent();

function itemEvent(){
for( i=0; i<item.length; i++){
	item[i].addEventListener('click', changeClass)
	}
}

function changeClass(){
	this.classList.toggle('selected');
}