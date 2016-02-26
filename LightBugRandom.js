#pragma strict

     var maxX = 6.1;
     var minX = -6.1;
     var maxY = 4.2;
     var minY = -4.2;
     
     private var timeChange: float = 0; // force new direction in the first Update
     private var randomX: float;
     private var randomY: float;
     private var moveSpeed: float = 0.5;
     public var orbitPointx: float = -4;
     public var orbitPointy: float = 4;
     
     function Update () {
         //random direction at random intervals
         if (Time.time >= timeChange){
             randomX = Random.Range(orbitPointx,orbitPointy); //float parameters, a random float
             randomY = Random.Range(orbitPointx,orbitPointy); //between -2.0 and 2.0 is returned
             //random interval between 0.5 and 1.5
             timeChange = Time.time + Random.Range(0.5,1.5);
         }
         transform.Translate(Vector3(randomX,randomY,0) * moveSpeed * Time.deltaTime);
         // if object reached any border, revert the appropriate direction
         if (transform.position.x >= maxX || transform.position.x <= minX) {
            randomX = -randomX;
         }
         if (transform.position.y >= maxY || transform.position.y <= minY) {
            randomY = -randomY;
         }
         // make sure the position is inside the borders
         transform.position.x = Mathf.Clamp(transform.position.x, minX, maxX);
         transform.position.y = Mathf.Clamp(transform.position.y, minY, maxY);
     }