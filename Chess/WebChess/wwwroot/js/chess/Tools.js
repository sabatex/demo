
// append div element and return new element;
export function appendDIV(htmlElement, styleClass, content) {
    let div = document.createElement("div");
    div.innerHTML = content;
    div.className = styleClass;
    htmlElement.appendChild(div);
    return div;
}

