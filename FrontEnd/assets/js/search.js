const rooms = [{
        id: 1,
        name: 'Luxury Room',
        price: '500$'
    },
    {
        id: 2,
        name: 'King Room',
        price: '600$'
    }
]
document.querySelector('.form-control.searching').addEventListener('keyup', function () {
    if (this.value !== '') {
        const a = rooms.filter((room) => {
            return room.name.toLowerCase().includes(this.value)
        })
        if (a.length !== 0) {
            document.querySelector('.search-results').innerHTML = ''
            a.forEach((result) => {
                const str = `
                    <li>
                    <div class="search-image-name">
                        <a href="">
                        <img src="assets/img/deluxe_room.jpg" alt="">
                        </a>
                        <a href="">
                         <p>${result.name}</p>
                        </a>
                    </div>
                    <p>Price: ${result.price}</p>
                    <input id='hiddenid' type="hidden" value="${result.id}">
                  </li>
                    `
                document.querySelector('.search-results').innerHTML += str
            })
        } else {
            document.querySelector('.search-results').innerHTML = ''
        }
    } else {
        document.querySelector('.search-results').innerHTML = ''
    }
})