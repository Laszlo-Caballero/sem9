$(document).ready(() => {
  const selectEstudiante = document.getElementById("selectEstudiante");
  const estudiantesDiv = document.getElementById("estudiantes");
  const estudiantes = [];
  selectEstudiante.addEventListener("change", function () {
    const selectedOption = this.options[this.selectedIndex];
    const idEstudiante = selectedOption.value;
    const nombreEstudiante = selectedOption.text;
    estudiantes.push(idEstudiante);

    const btn = document.createElement("button");
    btn.className = "btn btn-outline-primary";
    btn.textContent = nombreEstudiante;
    btn.setAttribute("data-id", idEstudiante);
    btn.type = "button";

    const input = document.createElement("input");
    input.type = "hidden";
    input.name = "idEstudiante";
    input.value = idEstudiante;
    btn.appendChild(input);

    btn.addEventListener("click", function () {
      const idEstudiante = this.getAttribute("data-id");
      estudiantes.filter((e) => e !== idEstudiante);

      estudiantesDiv.removeChild(btn);
    });

    estudiantesDiv.appendChild(btn);
  });
});
