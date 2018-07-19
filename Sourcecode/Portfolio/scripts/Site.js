Site = {};

Site.Initiate = function () {
    console.log('%c> Oh my heavens! What your doing here?! ಠ_ಠ', 'background: #e1e1e1; padding: 20px; color: black');

    Site.SetLanguages("#combobox-language-container", [{
            name: "English",
            code: "en-US",
            icon: "united-states-flag",
        }, {
            name: "Español",
            code: "es-ES",
            icon: "spain-flag"
        }, {
            name: "Français",
            code: "fr-FR",
            icon: "france-flag"
        },{
            name: "Português",
            code: "pt-BR",
            icon: "brazil-flag"
        }]);    

    function smoothScroll(to) {
        document.querySelector(to).scrollIntoView({
            behavior: 'smooth'
        });
    }

    $("#menu-sections a").click(function (event) {
        smoothScroll($(this).attr("href"));
        event.preventDefault();
    });

    particlesJS('particles',
        {
            "particles": {
                "number": {
                    "value": 80,
                    "density": {
                        "enable": true,
                        "value_area": 800
                    }
                },
                "color": {
                    "value": "#ffffff"
                },
                "shape": {
                    "type": "circle",
                    "stroke": {
                        "width": 0,
                        "color": "#000000"
                    },
                    "polygon": {
                        "nb_sides": 5
                    },
                    "image": {
                        "src": "img/github.svg",
                        "width": 100,
                        "height": 100
                    }
                },
                "opacity": {
                    "value": 0.5,
                    "random": false,
                    "anim": {
                        "enable": false,
                        "speed": 1,
                        "opacity_min": 0.1,
                        "sync": false
                    }
                },
                "size": {
                    "value": 5,
                    "random": true,
                    "anim": {
                        "enable": false,
                        "speed": 40,
                        "size_min": 0.1,
                        "sync": false
                    }
                },
                "line_linked": {
                    "enable": true,
                    "distance": 150,
                    "color": "#ffffff",
                    "opacity": 0.4,
                    "width": 1
                },
                "move": {
                    "enable": true,
                    "speed": 6,
                    "direction": "none",
                    "random": false,
                    "straight": false,
                    "out_mode": "out",
                    "attract": {
                        "enable": false,
                        "rotateX": 600,
                        "rotateY": 1200
                    }
                }
            },
            "interactivity": {
                "detect_on": "canvas",
                "events": {
                    "onhover": {
                        "enable": true,
                        "mode": "repulse"
                    },
                    "onclick": {
                        "enable": true,
                        "mode": "push"
                    },
                    "resize": true
                },
                "modes": {
                    "grab": {
                        "distance": 400,
                        "line_linked": {
                            "opacity": 1
                        }
                    },
                    "bubble": {
                        "distance": 400,
                        "size": 40,
                        "duration": 2,
                        "opacity": 8,
                        "speed": 3
                    },
                    "repulse": {
                        "distance": 200
                    },
                    "push": {
                        "particles_nb": 4
                    },
                    "remove": {
                        "particles_nb": 2
                    }
                }
            },
            "retina_detect": true,
            "config_demo": {
                "hide_card": false,
                "background_color": "#b61924",
                "background_image": "",
                "background_position": "50% 50%",
                "background_repeat": "no-repeat",
                "background_size": "cover"
            }
        }

    );
}

Site.ListLanguageIsOpen = false;

Site.ChangeLanguage = function (code) {
    $.ajax({
        url: "/home/setLanguage",
        data: {
            code: code
        },
        method: "POST",
        success: function () {
            location.reload();
        }
    });
}

Site.SetLanguages = function (target, languageArray) {
    var list = $('<div id="combobox-language-list"></div>');
    languageArray.forEach(function (item, itemIndex) {
        var itemLanguage = $('<div class="item-list"><i class="flag '+item.icon+'"></i>' + item.name + '</div>');
        list.append(itemLanguage);

        itemLanguage.click(function () {
            Site.ChangeLanguage(item.code);
        })
    });
    list.hide();
    $(target).append(list);

   /* $(target).click(function () {
        if (Site.ListLanguageIsOpen == false) {
            list.show();
            Site.ListLanguageIsOpen = true;
        } else {
            Site.ListLanguageIsOpen = false;
            list.hide();
        }
    });*/

    $(target).hover(function () {
        list.show();
        Site.ListLanguageIsOpen = true;
    });

    $(target).mouseleave(function () {
        Site.ListLanguageIsOpen = false;
        list.hide();
    });
}