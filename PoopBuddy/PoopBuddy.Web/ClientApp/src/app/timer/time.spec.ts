import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { Time } from './Time';

describe("Time",
  () => {
    it('should properly add miliseconds',
      () => {
        var timer = new Time();
        timer.addMs(1);
        expect(timer.miliSeconds).toBe(1);
        timer.addMs(10);
        expect(timer.miliSeconds).toBe(11);
      });

    it('should zero all values after resetting', () =>
    {
      var time = new Time();
      time.addMs(1000*60*60);
      time.addMs(1000*60*2);
      time.addMs(1000*3);
      time.addMs(8);

      expect(time.hours).toBe(1);
      expect(time.minutes).toBe(2);
      expect(time.seconds).toBe(3);
      expect(time.miliSeconds).toBe(8);

      time.reset();

      expect(time.hours).toBe(0);
      expect(time.minutes).toBe(0);
      expect(time.seconds).toBe(0);
      expect(time.miliSeconds).toBe(0);

    });

    it('should add second after 1000 ms',
      () => {
        var time = new Time();

        time.addMs(500);
        expect(time.seconds).toBe(0);

        time.addMs(400);
        expect(time.seconds).toBe(0);

        time.addMs(99);
        expect(time.seconds).toBe(0);

        time.addMs(1);
        expect(time.seconds).toBe(1);

      });

    it('should add 3 second after 3500 ms',
      () => {
        var time = new Time();

        time.addMs(3500);
        expect(time.seconds).toBe(3);
        expect(time.miliSeconds).toBe(500);
      });

    it('should add minute after 60 seconds',
      () => {
        var time = new Time();

        time.addMs(500);
        expect(time.seconds).toBe(0);

        time.addMs(400);
        expect(time.seconds).toBe(0);

        time.addMs(99);
        expect(time.seconds).toBe(0);

        time.addMs(1);
        expect(time.seconds).toBe(1);

      });

    it('should add hour after 60 minutes',
      () => {
        var time = new Time();


        
        expect(time.hours).toBe(0);
        expect(time.minutes).toBe(0);
        expect(time.seconds).toBe(0);
        expect(time.miliSeconds).toBe(0);

        time.addMs(1000*60*60);

        expect(time.hours).toBe(1);
        expect(time.minutes).toBe(0);
        expect(time.seconds).toBe(0);
        expect(time.miliSeconds).toBe(0);

      });
  });
