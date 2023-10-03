<?php
/*
 * HINDLEWARE
 * Copyright (C) 2022 Eric Hindle. All rights reserved.
 */
$currentlevel = 000;
$adminlevelneeded = 999;
$devlevelneeded = 901;
?>

<header>
	<link rel="stylesheet" href="/hindleware/css/nav.css">
	<a href="<?php echo $myPath; ?>menus/home.php"> <img
		src="<?php echo $myPath; ?>img/CelebBirthdayLogo.png" alt="logo"
		class="logo-image" width="250" />
	</a>
	
	 	<?php echo '<h3>'.$_SESSION['book_name'].'</h3>';?>
	
	<div class="account" style="z-index: 99;" onClick="menuToggle();">
		<span class="account-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/user.png)"></span>
		<div class="account-name"> 
		   	<?php echo $_SESSION['username'];?>
		</div>
		<div class="account-menu">
			<ul>
				<li>
					<form class="txt-btn" role="form" name="myaccount" method="post"
						action="<?php echo $myPath; ?>struct/player/myaccount.php">
					<?php echo $key; ?>
					<input id="submit" type="submit" value="Manage Your Account">
					</form>
				</li>
				<?php

if ($currentlevel == $adminlevelneeded || $currentlevel == $devlevelneeded) {
        echo '<li><a class="admin-btn" href="' . $myPath . 'struct/main.php">Admin</a></li>';
    }
    if ($currentlevel == $devlevelneeded) {
        echo '<li><a class="admin-btn" href="' . $myPath . 'menus\testmenu.php">Testing</a></li>';
    }
    ?>
				
				<li><a class="btn" href="<?php echo $myPath; ?>logout.php">Sign out</a></li>

			</ul>
		</div>
	</div>
</header>



<nav>
	<a
		class="nav-item <?php echo $currentPage == 'home' ? 'active' : ''; ?>"
		href="<?php echo $myPath; ?>menus/home.php"><span class="nav-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/home-grey.png)"></span>Home</a>
	<a
		class="nav-item <?php echo $currentPage == 'books' ? 'active' : ''; ?>"
		href="<?php echo $myPath; ?>books/selectbook.php"><span class="nav-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/book-grey.png)"></span>Books</a>
	<a
		class="nav-item <?php echo $currentPage == 'people' ? 'active' : ''; ?>"
		href="<?php echo $myPath; ?>people/selectperson.php"><span class="nav-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/people-grey.png)"></span>People</a>
	<a
		class="nav-item <?php echo $currentPage == 'places' ? 'active' : ''; ?>"
		href="<?php echo $myPath; ?>places/selectplace.php"><span class="nav-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/place-grey.png)"></span>Places</a>
	<a
		class="nav-item <?php echo $currentPage == 'events' ? 'active' : ''; ?>"
		href="<?php echo $myPath; ?>events/selectevent.php"><span class="nav-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/event-grey.png)"></span>Events</a>
	<a
		class="nav-item <?php echo $currentPage == 'sources' ? 'active' : ''; ?>"
		href="<?php echo $myPath; ?>sources/selectsource.php"><span class="nav-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/source-grey.png)"></span>Sources</a>
	<a
		class="nav-item <?php echo $currentPage == 'files' ? 'active' : ''; ?>"
		href="<?php echo $myPath; ?>menus/textmenu.php"><span class="nav-icon" style="background-image: url(<?php echo $myPath; ?>img/icons/text-grey.png)"></span>Files</a>
</nav>



<script>
	function menuToggle(){
		const toggleMenu = document.querySelector('.account');
		toggleMenu.classList.toggle('active')
	}
</script>

