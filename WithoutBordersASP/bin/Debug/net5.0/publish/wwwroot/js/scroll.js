// Smooth scrolling

const Scrolling = (function () {
    const ADDED_COEFFICIENT = 100
    const _headerHeight = document.getElementById('header').offsetHeight

    function getOffsetOf(element) {
        let rect = element.getBoundingClientRect(),
            scrollLeft = window.pageXOffset || document.documentElement.scrollLeft,
            scrollTop = window.pageYOffset || document.documentElement.scrollTop

        return {
            top: rect.top + scrollTop,
            left: rect.left + scrollLeft,
        }
    }

    class ScrlollingElement {
        constructor({ element, target }) {
            this.element = element
            this.target = document.querySelector(target)
            this.targetTopOffset = getOffsetOf(this.target).top
        }

        scroll() {
            const topOffsetWithHeaderHeight =
                this.targetTopOffset - _headerHeight - ADDED_COEFFICIENT

            window.scrollTo({
                top: topOffsetWithHeaderHeight,
                behavior: 'smooth',
            })
        }
    }

    // Return facade with main methods
    return {
        init: () => {
            const linksWithTargets = document.querySelectorAll('[data-target]')

            ;[...linksWithTargets].forEach((element) => {
                const target = element.dataset['target']

                const scrollingElem = new ScrlollingElement({
                    element: element,
                    target: target,
                })

                scrollingElem.element.addEventListener('click', () => {
                    scrollingElem.scroll()
                })
            })
        },
    }
})()

Scrolling.init()