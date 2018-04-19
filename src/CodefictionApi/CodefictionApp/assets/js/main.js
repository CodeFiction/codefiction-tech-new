/*
  Project Name : One Solution Multipurpose HTML Template
  Author Company : DenysThemes
  Project Date: 01 Jan, 2017
  Author Email : DenysThemes@gmail.com
*/

if ( Modernizr.strictmode ) {
    "use strict";
}

// IIFE function start here
( function( ) {

    /* page loder start here */
    jQuery( window ).on( 'load', function ( ) {
        jQuery( '.preloader-wrapper' ).fadeOut( );
        jQuery( '#about .heding-wrapper' ).addClass( 'animated' );
        //var scrollEvent = new Event( 'scroll' );
        //window.dispatchEvent( scrollEvent );

		if ( jQuery( '.grid' ).length ) {
			var grid = new Muuri( '.grid', {
				layout: {
					rounding: false
				}
			} );

			jQuery( '.portfolio-wrapper .filter-item' ).on( 'click', function( ) {
				var filterClass = jQuery( this ).data( 'filter' );
				if ( filterClass === 'all' ) {
					grid.filter( '.item' );
				} else {
					grid.filter( '.' + filterClass );
				}
			} );
		}
		
		var equalHeight = jQuery( '.equal-height' );
		if ( equalHeight.length ) {
			equalHeight.matchHeight( );
		}
    } );

	jQuery( document ).ready( function( jQuery ) {

		jQuery.stellar( {
			responsive: true,
			horizontalScrolling: false,
			verticalOffset: 40
		} );

        var body = jQuery( 'body' );

        // Theme options bar
        if ( jQuery( '#st-container' ).length ) {
            var patternsList = jQuery( '.patterns-list' );

            jQuery( '.toggle-panel, .st-pusher' ).on( 'click', function( ) {
                jQuery( '.st-container' ).toggleClass( 'st-menu-open' );
            } );

            function buttonActive( item ) {
                item.parent( ).find( '.item' ).removeClass( 'active' );
                item.addClass( 'active' );
            }

            function itemActive( item ) {
                item.closest( '.items-switcher' ).find( '.item' ).removeClass( 'active' );
                item.addClass( 'active' );
            }

            // Wide/Boxed type
            jQuery( '.wide-boxed-section' ).on( 'click', '.item', function( ) {
                buttonActive( jQuery( this ) );
                body.removeClass( ).addClass( jQuery( this ).attr( 'data-item' ) );
                body.attr( 'style', 'background-image: url(' + patternsList.find( '.active' ).data( 'path' ) + ');' )
                    .attr( 'data-bg-type', 'pattern' );
                //var resizeEvent = new Event( 'resize' );
                //window.dispatchEvent( resizeEvent );
            } );

            // Colors switcher
            jQuery( '.colors-list' ).on( 'click', '.item', function( event ) {
                var that = jQuery( this ),
                    colorPath = that.data( 'color-path' ),
                    logoPath = that.data( 'logo-path' ),
                    footerLogoPath = that.data( 'footer-logo-path' );
                itemActive( that );
                jQuery( '#color-file' ).attr( 'href', colorPath );
                jQuery( '.logo-container img' ).attr( 'src', logoPath );
                jQuery( '.footer-logo img' ).attr( 'src', footerLogoPath );
            } );

            // Header positions switcher
			var header = jQuery( 'header' );
            jQuery( '.header-positions' ).on( 'click', '.item', function( ) {
                buttonActive( jQuery( this ) );
                header.attr( 'data-position', jQuery( this ).attr( 'data-item' ) );
            } );

            // Patterns switcher
            patternsList.on( 'click', '.item', function( event ) {
                var that = jQuery( this ),
                    path = that.data( 'path' );
                itemActive( that );
                body.attr( 'data-bg-type', 'pattern' ).attr( 'style', 'background-image: url(' + path + ');' );
            } );

            // Backgrounds switcher
            jQuery( '.backgrounds-list' ).on( 'click', '.item', function( event ) {
                var that = jQuery( this ),
                    path = that.data( 'path' );
                itemActive( that );
                body.attr( 'data-bg-type', 'background' ).attr( 'style', 'background-image: url(' + path + ');' );
            } );
        }

        // Function remove by timer for success or error AJAX finish
        function removeByTimer( selector, timeout ) {
            setTimeout( function( ) {
                selector.remove( );
            }, timeout );
        }

        // Function append alert for success or error AJAX finish
        function appendAllert( message ) {
            body.append( '<div class="form-alert c-table">' +
                            '<div class="c-row">' +
                                '<div class="c-cell">' +
                                    '<div class="alert-content">' + message + '</div>' +
                                '</div>' +
                            '</div>' +
                        '</div>' );
            removeByTimer( body.find( '.form-alert' ), 1500 );
			jQuery( '.submit' ).blur( );
        }

        // AJAX handler of sending form
        jQuery( '.contact-form, .page-contact-form' ).on( 'click', '.submit', function( event ) {
            event.preventDefault( );
            var formClassName = $( event.delegateTarget ),
				nameField = formClassName.find( '.name' ),
                emailField = formClassName.find( '.email' ),
                messageField = formClassName.find( '.message' ),
                nameData = nameField.val( ),
                emailData = emailField.val( ),
                messageData = messageField.val( ),
                successMessage = 'Message has been sent.',
                errorMessage = 'Message was not sent.';

			// Form validation
			if( !nameData )
			{
				nameField.addClass( 'not-valid' );
				appendAllert( 'Please enter a name' );
				return;
			}
			
			if( !/^([a-zA-Z0-9_.-])+@(([a-zA-Z0-9-])+.)+([a-zA-Z0-9]{2,4})+$/.test( emailData ) )
			{
				emailField.addClass( 'not-valid' );
				appendAllert( 'Please enter a valid email address' );
				return;
			}
			
            if ( !messageData ) {
				messageField.addClass( 'not-valid' );
				appendAllert( 'Please enter a message' );
                return;
            }

            jQuery.post( 'assets/php/mail.php', {
                    name: nameData,
                    email: emailData,
                    message: messageData,
                }, 'json' ).done( function( data, textStatus ) {
					var response = jQuery.parseJSON( data );
					if( response.status )
					{
						appendAllert( successMessage );
						nameField.add( emailField ).add( messageField ).val( '' );
					}
					else
					{
						appendAllert( errorMessage );
					}
                } ).fail( function( xhr, status, error ) {
                    appendAllert( errorMessage );
                } );
        } );
		
		jQuery( '.contact-form input:not(.submit), .contact-form textarea, .page-contact-form input:not(.submit), .page-contact-form textarea' ).on( 'focus', function( )
		{
			jQuery( this ).removeClass( 'not-valid' );
		} );

    	// start gallery and images view here
        jQuery( '.gallery:first a[class^="pretty"]' ).prettyPhoto( {
            animation_speed: 'normal',
            theme: 'light_square',
            slideshow: 3000,
            autoplay_slideshow: false,
            social_tools: false,
            deeplinking: false,
        } );
        // Adding active class for navigation here
        jQuery( '.main-nav a' ).on( 'click', function( ) {
            jQuery( '.main-nav li' ).removeClass( 'active' );
            jQuery( this ).parent( ).addClass( 'active' );
        } );
    	// Start portfolio Filter here
        jQuery( '.portfolio-filter .filter-item' ).on( 'click', function( ) {
			jQuery( '.portfolio-filter li' ).removeClass( 'active' );
			jQuery( this ).parent( ).addClass( 'active' );
        } );
        // Start SCROLL TO FIX HEADER
		var topbar = jQuery( '.top-bar' );
        jQuery( window ).on( 'scroll', function( ) {
            if ( jQuery(window).scrollTop() >= topbar.height( ) ) {
                body.addClass( 'sticky' );
            } else {
                body.removeClass( 'sticky' );
            }
        } );
        // Show element on scroll
        jQuery( '.animate-in' ).viewportChecker( {
			classToAdd: 'animated',
			callbackFunction: function( elem, action ) {
				if ( elem.hasClass( 'progress' ) ) {
					jQuery( '.progress .progress-bar' ).css( 'width', function( ) {
						return jQuery( this ).attr( 'aria-valuenow' ) + "%";
					} );
				}
			}
		} );

        // SCROLL TO TARGET
        jQuery( '.scroll' ).on( 'click', function( event ) {
            //calculate destination place
            var dest = 0;
			if ( jQuery( this.hash ).offset( ) ) {
				event.preventDefault( );
				if( jQuery( this.hash ).offset( ).top > jQuery( document ).height( ) - jQuery( window ).height( ) ) {
					dest = jQuery( document ).height( ) - jQuery( window ).height( );
				} else {
					dest = jQuery( this.hash ).offset( ).top - header.height( );
				}
			}
            //go to destination
            jQuery( 'html, body' ).animate( { scrollTop: dest }, 600, 'swing' );
        } );

        // Sliders Start here
        jQuery( '.testimonial-slider' ).owlCarousel( {
			loop: true,
            nav: false,
			dots: false,
			autoplaySpeed: 300,
			navSpeed: 300,
			dotsSpeed: 400,
			dragEndSpeed: 300,
			autoplayTimeout: 4000,
			items: 1,
			autoplay: true,
			autoplayHoverPause: true,
        } );
		
        jQuery( '#client-slider' ).owlCarousel( {
			loop: true,
            nav: false,
			autoplaySpeed: 300,
			navSpeed: 300,
			dotsSpeed: 400,
			dragEndSpeed: 300,
			autoplayTimeout: 4000,
			autoplay: true,
			autoplayHoverPause: true,
			items: 4,
			responsive: {
				0: {
					items: 1,
				},
				600: {
					items: 2,
				},
				978: {
					items: 3,
				},
				1199: {
					items: 4,
				}
			}
        } );
		
		jQuery( '.simple-slider' ).owlCarousel( {
			items: 1,
			loop: true,
		} );

        // Lightbox options here
		lightbox.option( {
			'resizeDuration': 200,
			'wrapAround': true
		} );

        // Open/close primary navigation
        var menuButton = jQuery( '.cd-menu-icon' );
        jQuery( '.cd-primary-nav-trigger' ).on( 'click', function( e ) {
            jQuery( 'body' ).addClass( 'show-menu' );
            menuButton.addClass( 'is-clicked' );
        } );

        jQuery( '#close-button, .menu-shadow' ).on( 'click', function( e ) {
            jQuery( 'body' ).removeClass( 'show-menu' );
            if ( e.target.className === 'close-button' || e.target.className === 'menu-shadow' ) {
                jQuery( this ).parent( ).find( '.menu .has-sub .sub' ).slideUp( );
                menuButton.removeClass( 'is-clicked' );
            }
        } );

        // Add css3 transform for animation in primary navigation
        var menuItems = jQuery( '.menu-container .menu > ul > li' );
        for ( var i = 0, menuItemsLength = menuItems.length, translateVal = 500; i < menuItemsLength; i++ ) {
            translateVal += 500;
            menuItems.eq( i ).css( {
                '-webkit-transform': 'translate3d(0,' + translateVal + 'px,0)',
            	'transform': 'translate3d(0,' + translateVal + 'px,0)'
            } );
        }

        // Open/close submenu
        menuItems.children( 'a' ).on( 'click', function( e ) {
            if ( jQuery( this ).closest( 'li' ).hasClass( 'has-sub' ) ) {
				e.preventDefault( );
                jQuery( this ).next( ).slideToggle( );
            }
        } );
		
		// Desctop menu hover reaction
		var menuItems = $( 'nav.main-nav li' );
        menuItems.hover( function( )
        {
            $( this ).children( '.sub' ).stop( true ).fadeIn( 300 );
        }, function ( )
        {
            $( this ).children( '.sub' ).stop( true ).fadeOut( 100 );
        } );

        //Check to see if the window is top if not then display button
        jQuery( window ).on( 'scroll', function( ) {
            if ( jQuery( this ).scrollTop( ) > 100 ) {
                jQuery( '.scrollToTop' ).fadeIn( );
            } else {
                jQuery( '.scrollToTop' ).fadeOut( );
            }
        } );

        //Click event to scroll to top
        jQuery( '.scrollToTop' ).on( 'click', function( ) {
            jQuery( 'html, body' ).animate( { scrollTop : 0 }, 600 );
            return false;
        } );

        //start tabs here
        jQuery( '.nav-tabs a' ).on( 'click', function( e ) {
            e.preventDefault( );
            jQuery( this ).tab( 'show' );
        } );

    } );
} ) ( );
