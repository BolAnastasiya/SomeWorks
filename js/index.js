class Game {
    constructor() {
        this.mapWidth = 40;
        this.mapHeight = 24;
        this.map = [];

        // Инициализируем игрока и противников
        this.player = {x: 0, y: 0, health: 100, power: 10};
        this.enemies = [];

        // Инициализируем переменные для хранения координат игрока
        this.playerX = 0;
        this.playerY = 0;

        // Создаем карту
        this.generateMap();

        // Помещаем героя в случайное пустое место
        this.placeHeroRandomly();

        // Помещаем противников в случайные пустые места
        this.placeEnemiesRandomly(10);

        // Инициализируем игру
        this.init();

        // Добавляем обработчик событий для управления героем клавишами WASD
        document.addEventListener('keydown', this.handleKeyPress.bind(this));

        // Добавляем обработчик событий для нажатия клавиши пробел
        document.addEventListener('keypress', this.handleSpaceKeyPress.bind(this));

        // Добавляем уровень здоровья игроку
        this.player.health = 100;

        // Добавляем уровень здоровья противникам
        for (const enemy of this.enemies) {
            enemy.health = 100;
        }
        
        //Инициализируем перемещение противников
        this.startEnemyMovement();
        
        // Инициализируем переменные для хранения начального положения игрока и противников
        this.initialPlayerPosition = { x: this.player.x, y: this.player.y };
        this.initialEnemiesPositions = this.enemies.map(enemy => ({ x: enemy.x, y: enemy.y }));
  
         
    }
      

    init() {
        this.renderMap();
    }

    // Генерация случайного числа в диапазоне [min, max]
    getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
    
    // Генерация карты
    generateMap() {
        // Создаем карту 40x24 и заполняем ее стенами
        this.map = Array.from({ length: this.mapHeight }, () => Array(this.mapWidth).fill('#'));

        // Создаем случайное количество горизонтальных и вертикальных проходов
        const minPassages = 3;
        const maxPassages = 5;
        const numHorizontalPassages = this.getRandomInt(minPassages, maxPassages);
        const numVerticalPassages = this.getRandomInt(minPassages, maxPassages);

        // Размещаем горизонтальные проходы
        for (let i = 0; i < numHorizontalPassages; i++) {
            const y = this.getRandomInt(1, this.mapHeight - 2); 
            for (let x = 0; x < this.mapWidth; x++) {
                this.map[y][x] = '.';
            }
        }

        // Размещаем вертикальные проходы
        for (let i = 0; i < numVerticalPassages; i++) {
            const x = this.getRandomInt(1, this.mapWidth - 2); 
            for (let y = 0; y < this.mapHeight; y++) {
                this.map[y][x] = '.';
            }
        }

        // Создаем случайное количество комнат
        const minRooms = 5;
        const maxRooms = 10;
        const numRooms = this.getRandomInt(minRooms, maxRooms);

        const rooms = [];
        for (let i = 0; i < numRooms; i++) {
            let room;
            let intersects;
            do {
                intersects = false;
                room = this.generateRandomRoom();
                room.x = this.getRandomInt(1, this.mapWidth - room.width - 1);
                room.y = this.getRandomInt(1, this.mapHeight - room.height - 1);

                // Проверяем, не пересекается ли комната с другими комнатами
                for (const otherRoom of rooms) {
                    if (room.x < otherRoom.x + otherRoom.width &&
                        room.x + room.width > otherRoom.x &&
                        room.y < otherRoom.y + otherRoom.height &&
                        room.y + room.height > otherRoom.y) {
                        intersects = true;
                        break;
                    }
                }
            } while (intersects);

            // Добавляем комнату в список комнат
            rooms.push(room);

            // Размещаем комнату на карту
            for (let y = room.y; y < room.y + room.height; y++) {
                for (let x = room.x; x < room.x + room.width; x++) {
                    this.map[y][x] = '.';
                }
            }
        }

        // Размещаем предметы только внутри комнат
        this.placeItemsInRooms();
        this.placeItemsInRoomsHP();
    }
 
    // Размещение предметов (мечей) только внутри комнат
    placeItemsInRooms() {
        const numSwords = 2; 
        let placedSwords = 0; 

        for (let y = 0; y < this.mapHeight; y++) {
            for (let x = 0; x < this.mapWidth; x++) {
                // Если текущая клетка - часть комнаты, размещаем меч внутри нее
                if (this.map[y][x] === '.') {
                    // Проверяем, есть ли уже меч в этой клетке
                    if (placedSwords < numSwords) {
                        // Размещаем меч в этой клетке
                        this.map[y][x] = 'S';
                        placedSwords++; // Увеличиваем количество размещенных мечей
                    }
                }
            }
        }
    }

    // Размещение предметов (зелей) только внутри комнат
    placeItemsInRoomsHP() {
        const numPotions = 10; 
        let placedPotions = 0; 
        const availableCells = []; // Массив доступных клеток для размещения зелий

        for (let y = 0; y < this.mapHeight; y++) {
            for (let x = 0; x < this.mapWidth; x++) {
                // Если текущая клетка - часть комнаты, добавляем ее в массив доступных клеток
                if (this.map[y][x] === '.') {
                    availableCells.push({x, y});
                }
            }
        }

        // Пока не разместили все зелья
        while (placedPotions < numPotions) {
            // Получаем случайную доступную клетку из массива
            const randomIndex = this.getRandomInt(0, availableCells.length - 1);
            const randomCell = availableCells[randomIndex];

            // Размещаем зелье в этой случайной клетке
            this.map[randomCell.y][randomCell.x] = 'H';
            placedPotions++; // Увеличиваем количество размещенных зелий

            // Удаляем использованную клетку из массива доступных клеток
            availableCells.splice(randomIndex, 1);
        }
    }

    // Добавляем метод для помещения героя в случайное пустое место
    placeHeroRandomly() {
        const availableCells = [];
        for (let y = 0; y < this.mapHeight; y++) {
            for (let x = 0; x < this.mapWidth; x++) {
                // Если текущая клетка пустая, добавляем ее в массив доступных клеток
                if (this.map[y][x] === '.') {
                    availableCells.push({x, y});
                }
            }
        }

        // Выбираем случайную клетку из массива доступных клеток
        const randomIndex = this.getRandomInt(0, availableCells.length - 1);
        const randomCell = availableCells[randomIndex];

        // Помещаем героя в выбранную случайную клетку
        this.player.x = randomCell.x;
        this.player.y = randomCell.y;
    }

    // Добавляем метод для помещения противников в случайные пустые места
    placeEnemiesRandomly(numEnemies) {
        for (let i = 0; i < numEnemies; i++) {
            const enemy = {x: 0, y: 0, health: 50, power: 5}; 
            let x, y;
            // Пока не найдем пустую клетку для размещения противника
            do {
                x = this.getRandomInt(0, this.mapWidth - 1);
                y = this.getRandomInt(0, this.mapHeight - 1);
            } while (this.map[y][x] !== '.');

            // Помещаем противника в найденную пустую клетку
            enemy.x = x;
            enemy.y = y;
            // Добавляем противника в массив противников
            this.enemies.push(enemy);
        }
    }
    
    // Генерация случайной комнаты
    generateRandomRoom() {
        const minWidth = 3; 
        const maxWidth = 8; 
        const minHeight = 3; 
        const maxHeight = 8; 

        // Генерируем случайные размеры комнаты
        const width = this.getRandomInt(minWidth, maxWidth);
        const height = this.getRandomInt(minHeight, maxHeight);

        return { width, height };
    }

    renderMap() {
        const field = document.querySelector('.field');
        field.innerHTML = '';

        // Отображаем карту
        for (let y = 0; y < this.mapHeight; y++) {
            for (let x = 0; x < this.mapWidth; x++) {
                const tile = document.createElement('div');
                tile.classList.add('tile');

                // Отображаем уровень здоровья для игрока
                if (x === this.player.x && y === this.player.y) {
                    const healthBar = document.createElement('div');
                    healthBar.classList.add('health');
                    healthBar.style.width = this.player.health + '%';
                    tile.appendChild(healthBar);
                }

                // Отображаем уровень здоровья для противников
                for (const enemy of this.enemies) {
                    if (x === enemy.x && y === enemy.y) {
                        const healthBar = document.createElement('div');
                        healthBar.classList.add('health');
                        healthBar.style.width = enemy.health + '%';
                        tile.appendChild(healthBar);
                    }
                }

                if (this.map[y][x] === '#') {
                    tile.classList.add('tileW'); // Стена
                } else if (this.map[y][x] === '.') {
                    tile.classList.add('tile'); // Пол
                } else if (this.map[y][x] === 'S') {
                    tile.classList.add('tileSW'); // Меч
                } else if (this.map[y][x] === 'H') {
                    tile.classList.add('tileHP'); // Зелье здоровья
                }
                // Проверяем, является ли текущая клетка позицией игрока
                if (x === this.player.x && y === this.player.y) {
                    tile.classList.add('tileP'); // Герой
                }
                // Проверяем, является ли текущая клетка позицией противника
                for (const enemy of this.enemies) {
                    if (x === enemy.x && y === enemy.y) {
                        tile.classList.add('tileE'); // Противник
                    }
                }
                // Рассчитываем позицию клетки на основе ее координат
                const tilePosX = x * 25.7;  
                const tilePosY = y * 26.7; 
                tile.style.left = tilePosX + 'px';
                tile.style.top = tilePosY + 'px';
                field.appendChild(tile);
            }
        }
    }

    // Метод для перезагрузки карты 
    reloadMap() {
        // Сохраняем текущие координаты игрока
        this.playerX = this.player.x;
        this.playerY = this.player.y;

        // Перезагружаем карту
        this.generateMap();

        // Устанавливаем позицию игрока на новой карте
        this.player.x = this.playerX;
        this.player.y = this.playerY;

        // Перерисовываем карту
        this.renderMap();
    }

    // Обработчик нажатия клавиш
    handleKeyPress(event) {
        const key = event.key.toLowerCase();
        const player = this.player;

        switch (event.code) {
            case 'KeyW': // Вверх
                this.movePlayer(player.x, player.y - 1);
            break;
            case 'KeyA': // Влево
                this.movePlayer(player.x - 1, player.y);
            break;
            case 'KeyS': // Вниз
                this.movePlayer(player.x, player.y + 1);
            break;
            case 'KeyD': // Вправо
                this.movePlayer(player.x + 1, player.y);
            break;
        }
    }




    // Метод для перемещения противников
    moveEnemies() {
        for (const enemy of this.enemies) {
            // Генерируем случайное число, чтобы определить направление передвижения: 0 - горизонтальное, 1 - вертикальное
            const direction = Math.floor(Math.random() * 2);

            // Горизонтальное передвижение
            if (direction === 0) {
                // Генерируем случайное число, чтобы определить направление движения: -1 - влево, 1 - вправо
                const stepX = Math.random() < 0.5 ? -1 : 1;
                const newX = enemy.x + stepX;

                // Проверяем, находится ли новая позиция противника в пределах карты и является ли клетка доступной
                if (this.isInMap(newX, enemy.y) && this.map[enemy.y][newX] === '.') {
                    enemy.x = newX;
                }
            } 
            // Вертикальное передвижение
            else {
                // Генерируем случайное число, чтобы определить направление движения: -1 - вверх, 1 - вниз
                const stepY = Math.random() < 0.5 ? -1 : 1;
                const newY = enemy.y + stepY;

                // Проверяем, находится ли новая позиция противника в пределах карты и является ли клетка доступной
                if (this.isInMap(enemy.x, newY) && this.map[newY][enemy.x] === '.') {
                enemy.y = newY;
                }
            }
        }
        // Перерисовываем карту после перемещения противников
        this.renderMap();
    }


    // Метод для проверки, находится ли координата в пределах карты
    isInMap(x, y) {
        return x >= 0 && x < this.mapWidth && y >= 0 && y < this.mapHeight;
    }

    // Обработчик нажатия клавиши пробел
    handleSpaceKeyPress(event) {
        if (event.key === ' ') {
            this.attackEnemies();
        }
    }

    // Метод для атаки всех противников на соседних клетках
    attackEnemies() {
        const adjacentCells = [
            { x: this.player.x - 1, y: this.player.y },
            { x: this.player.x + 1, y: this.player.y },
            { x: this.player.x, y: this.player.y - 1 },
            { x: this.player.x, y: this.player.y + 1 }
        ];

        for (const enemy of this.enemies) {
            for (const cell of adjacentCells) {
                if (enemy.x === cell.x && enemy.y === cell.y) {
                    this.attackEnemy(enemy);
                }
            }
        }
    }

    // Метод для атаки противника
    attackEnemy(enemy) {
        enemy.health -= this.player.power;
        if (enemy.health <= 0) {
            this.removeEnemy(enemy);
        }
        this.renderMap();
    }

    // Метод для удаления противника из массива и карты
    removeEnemy(enemy) {
        const index = this.enemies.indexOf(enemy);
        if (index !== -1) {
            this.enemies.splice(index, 1);
            this.map[enemy.y][enemy.x] = '.';
        }
    }


    // Метод для перемещения игрока с учетом восстановления здоровья и подбора предметов
    movePlayer(newX, newY) {
        // Проверяем, находится ли новая позиция игрока в пределах карты и является ли клетка проходимой
        if (this.isInMap(newX, newY) && this.map[newY][newX] !== '#') {
            // Перемещаем игрока
            this.player.x = newX;
            this.player.y = newY;
            // Если на клетке зелье здоровья
            if (this.map[newY][newX] === 'H') {
                // Восстанавливаем здоровье игрока
                this.player.health += 15; // Например, восстанавливаем 15 единиц здоровья
                if (this.player.health > 100) { // Здоровье не должно превышать 100
                    this.player.health = 100;
                }
            } else if (this.map[newY][newX] === 'S') { // Если на клетке меч
                // Добавляем меч герою
                this.player.power += 5; // Например, увеличиваем силу героя на 5 единиц
            }
            // Убираем предмет с карты после подбора
            this.map[newY][newX] = '.';
            // Проверяем атаку противников
            this.attackEnemies();
        }
        // Перерисовываем карту
        this.renderMap();
    }



    // Метод для атаки всех противников на соседних клетках
    attackEnemies() {
        const adjacentCells = [
            { x: this.player.x - 1, y: this.player.y },
            { x: this.player.x + 1, y: this.player.y },
            { x: this.player.x, y: this.player.y - 1 },
            { x: this.player.x, y: this.player.y + 1 }
        ];

        for (const enemy of this.enemies) {
            for (const cell of adjacentCells) {
                if (enemy.x === cell.x && enemy.y === cell.y) {
                    // Атакуем противника
                    this.attackEnemy(enemy);
                    // Проверяем, не убит ли противник
                    if (enemy.health <= 0) {
                        // Удаляем убитого противника из массива и карты
                        this.removeEnemy(enemy);
                    }
                    // Уменьшаем здоровье игрока на силу противника
                    this.player.health -= enemy.power;
                    // Проверяем, не умер ли игрок
                    if (this.player.health <= 0) {
                        // Если умер, выводим сообщение об окончании игры
                        alert('Игра окончена');
                    
                    }
                    // Перерисовываем карту
                    this.renderMap();
                    return; // Прерываем выполнение, чтобы не атаковать несколько противников одновременно
                }
            }
        }
    }

    //Метод для перемещения противников
    startEnemyMovement() {
        this.enemyMovementInterval = setInterval(() => {
            for (const enemy of this.enemies) {
                const enemyX = enemy.x;
                const enemyY = enemy.y;

                // Проверяем, есть ли противник рядом с героем
                const isEnemyNearPlayer = this.isEnemyNearPlayer(enemyX, enemyY);

                if (isEnemyNearPlayer) {
                    // Противник находится рядом с героем, пропускаем его ход
                    continue;
                }

                // Остальная логика перемещения противника
                const wallLeft = this.isWall(enemyX - 1, enemyY);
                const wallRight = this.isWall(enemyX + 1, enemyY);
                const wallUp = this.isWall(enemyX, enemyY - 1);
                const wallDown = this.isWall(enemyX, enemyY + 1);

                // Определяем доступные направления движения для противника
                const availableDirections = [];
                if (!wallLeft) availableDirections.push('left');
                if (!wallRight) availableDirections.push('right');
                if (!wallUp) availableDirections.push('up');
                if (!wallDown) availableDirections.push('down');

                // Выбираем случайное доступное направление движения
                const randomDirection = availableDirections[Math.floor(Math.random() * availableDirections.length)];

                // Двигаем противника в выбранном направлении
                switch (randomDirection) {
                    case 'left':
                        enemy.x -= 1;
                    break;
                    case 'right':
                        enemy.x += 1;
                    break;
                    case 'up':
                        enemy.y -= 1;
                    break;
                    case 'down':
                        enemy.y += 1;
                    break;
                }
            }
            this.renderMap();
        }, 1500);
    }

    // Метод для проверки, есть ли противник рядом с игроком
    isEnemyNearPlayer(enemyX, enemyY) {
        const playerX = this.player.x;
        const playerY = this.player.y;

        // Проверяем наличие противника на соседних клетках
        return (
            (Math.abs(playerX - enemyX) === 1 && playerY === enemyY) || // Слева или справа от игрока
            (Math.abs(playerY - enemyY) === 1 && playerX === enemyX)    // Сверху или снизу от игрока
        );
    }

    // Метод для проверки, является ли клетка стеной
    isWall(x, y) {
        return this.isInMap(x, y) && this.map[y][x] === '#';
    }


}

// Создаем игру и инициализируем ее при загрузке страницы
window.onload = function() {
const game = new Game();
game.init();
};
