var scale = 20;

function draw(array) {
    var canvas = document.getElementById('canvas');
    var ctx = canvas.getContext('2d');
    ctx.clearRect(0, 0, 0, 0);
    canvas.height = array.length * scale;
    canvas.width = array[0].length * scale;


    for (var keyX in array) {
        for (var keyY in array[keyX]) {
            if (array[keyX][keyY].open == false) {
                ctx.fillStyle = 'rgb(0, 0, 0)'
            } else if (array[keyX][keyY].debut == true) {
                ctx.fillStyle = 'rgb(0, 255, 0)';
            } else if (array[keyX][keyY].fin == true) {
                ctx.fillStyle = 'rgb(255, 0, 0)';
            } else if (array[keyX][keyY].impasse == true) {
                ctx.fillStyle = 'rgb(255, 215, 0)';
            } else {
                ctx.fillStyle = 'rgb(255, 255, 255)';
            }
            ctx.fillRect(keyX * scale, keyY * scale, scale, scale)
        }
    }
}

function generation(array) {
    var height = array.length;
    var width = array[0].length;
    var path = [{ x: Math.floor(Math.random() * (height - 0)) + 0, y: Math.floor(Math.random() * (width - 0)) + 0 }]
    var nbLast = null;
    var last = null;
    var impasse = false;
    var i = 0;

    array[path[path.length - 1].x][path[path.length - 1].y].open = true;
    array[path[path.length - 1].x][path[path.length - 1].y].debut = true;

    while (path.length > 0) {


        //verification nouvelle direction
        var directionValue = { x: 0, y: 0 };
        var directionTeste = [];
        var back = false;
        var verif = false;
        while (!back) {

            directionName = null;

            random();

            function random() {
                if (Math.random() < 0.5) {
                    Math.random() < 0.5 == true ?
                        directionName = "UP" : directionName = "DOWN"
                } else {
                    Math.random() < 0.5 == true ?
                        directionName = "RIGHT" : directionName = "LEFT"
                }
                if (directionTeste.length >= 4) {
                    back = true;
                    verif = false;
                    if (nbLast < path.length) {
                        nbLast = path.length;
                        last = path[path.length - 1];
                        array[path[path.length - 1].x][path[path.length - 1].y].impasse = true;
                    }
                    impasse = true;
                    path.pop();
                } else if (directionTeste.includes(directionName)) { random() }
            }

            if (directionName == "UP") { directionValue = { x: 0, y: -2 } } else if (directionName == "DOWN") { directionValue = { x: 0, y: +2 } } else if (directionName == "RIGHT") { directionValue = { x: +2, y: 0 } } else if (directionName == "LEFT") { directionValue = { x: -2, y: 0 } }

            if (back != true) {
                if (path[path.length - 1].x + directionValue.x >= 0 && path[path.length - 1].x + directionValue.x < width && path[path.length - 1].y + directionValue.y >= 0 && path[path.length - 1].y + directionValue.y < height) {
                    if (array[path[path.length - 1].x + directionValue.x][path[path.length - 1].y + directionValue.y].open != true) {
                        back = true;
                        verif = true;
                        impasse = false;
                        directionTeste.push(directionName);
                    } else {
                        directionValue = { x: 0, y: 0 };
                        directionTeste.push(directionName)
                    }
                } else {
                    directionValue = { x: 0, y: 0 };
                    directionTeste.push(directionName)
                }
            }
        }

        if (impasse == false) {
            console.log("test")
            impasse = false;
        }


        if (verif) {
            array[path[path.length - 1].x + directionValue.x][path[path.length - 1].y + directionValue.y].open = true;
            array[path[path.length - 1].x + directionValue.x / 2][path[path.length - 1].y + directionValue.y / 2].open = true;
            path.push({ x: path[path.length - 1].x + directionValue.x, y: path[path.length - 1].y + directionValue.y });
            i++
        }

    }
    array[last.x][last.y].fin = true;

    return (array);


}


function main() {

    lab = [];
    var taille = 50;
    for (let y = 0; y < taille; y++) {
        const ligne = [];
        for (let x = 0; x < taille; x++) {
            ligne.push({
                open: false,
                debut: false,
                fin: false,
                impasse: false

            })
        }
        lab.push(ligne)
    }

    draw(generation(lab));

}