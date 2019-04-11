import { TestBed, async, fakeAsync, tick } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { Timer } from './Timer';
import {Time} from "../time/Time"


function assertAllValuesAreZero(time:Time) {
  expect(time.miliSeconds).toBe(0);
  expect(time.seconds).toBe(0);
  expect(time.minutes).toBe(0);
  expect(time.hours).toBe(0);
}

describe("Timer",
  () => {

    var timer : Timer;

    beforeEach(() => {
      if (timer != null)
        timer.reset();
      timer = new Timer();
    });

    afterEach(() => {
      if(timer != null)
        timer.reset();
      timer = null;
    });

    it('should properly add ms after time passes',
      fakeAsync(() => {
        var timer = new Timer();
        timer.start();
        tick(100);
        timer.stop();
        expect(timer.time.miliSeconds).toBe(100);
        tick(1000);
        expect(timer.time.seconds).toBe(0);
        expect(timer.time.miliSeconds).toBe(100);
      }));

    it('should reset time after reseting',
      fakeAsync(() => {
        var timer = new Timer();
        timer.start();
        tick(1000 * 60);
        expect(timer.time.minutes).toBe(1);
        timer.reset();
        assertAllValuesAreZero(timer.time);
      }));

    it('should not reset when stopped and started',
      fakeAsync(() => {
        var timer = new Timer();
        timer.start();
        tick(1000 * 23);
        expect(timer.time.seconds).toBe(23);
        timer.stop();
        expect(timer.time.seconds).toBe(23);
        tick(1000 * 23);
        expect(timer.time.seconds).toBe(23);
        timer.start();
        tick(1000 * 23);
        expect(timer.time.seconds).toBe(46);
        timer.reset();
      }));


  });
